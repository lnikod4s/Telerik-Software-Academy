using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Microsoft._3DTools
{
	/// <summary>
	///     Trackball is a utility class which observes the mouse events
	///     on a specified FrameworkElement and produces a Transform3D
	///     with the resultant rotation and scale.
	///     Example Usage:
	///     Trackball trackball = new Trackball();
	///     trackball.EventSource = myElement;
	///     myViewport3D.Camera.Transform = trackball.Transform;
	///     Because Viewport3Ds only raise events when the mouse is over the
	///     rendered 3D geometry (as opposed to not when the mouse is within
	///     the layout bounds) you usually want to use another element as
	///     your EventSource.  For example, a transparent border placed on
	///     top of your Viewport3D works well:
	///     <Grid>
	///         <ColumnDefinition />
	///         <RowDefinition />
	///         <Viewport3D Name="myViewport" ClipToBounds="True" Grid.Row="0" Grid.Column="0" />
	///         <Border Name="myElement" Background="Transparent" Grid.Row="0" Grid.Column="0" />
	///     </Grid>
	///     NOTE: The Transform property may be shared by multiple Cameras
	///     if you want to have auxilary views following the trackball.
	///     It can also be useful to share the Transform property with
	///     models in the scene that you want to move with the camera.
	///     (For example, the Trackport3D's headlight is implemented
	///     this way.)
	///     You may also use a Transform3DGroup to combine the
	///     Transform property with additional Transforms.
	/// </summary>
	public class Trackball
	{
		private readonly AxisAngleRotation3D _rotation = new AxisAngleRotation3D();
		private readonly ScaleTransform3D _scale = new ScaleTransform3D();
		private readonly Transform3DGroup _transform;
		private FrameworkElement _eventSource;
		private Point _previousPosition2D;
		private Vector3D _previousPosition3D = new Vector3D(0, 0, 1);

		public Trackball()
		{
			this._transform = new Transform3DGroup();
			this._transform.Children.Add(this._scale);
			this._transform.Children.Add(new RotateTransform3D(this._rotation));
		}

		/// <summary>
		///     A transform to move the camera or scene to the trackball's
		///     current orientation and scale.
		/// </summary>
		public Transform3D Transform
		{
			get { return this._transform; }
		}

		private void Track(Point currentPosition)
		{
			var currentPosition3D = this.ProjectToTrackball(this.EventSource.ActualWidth, this.EventSource.ActualHeight,
			                                                currentPosition);

			var axis = Vector3D.CrossProduct(this._previousPosition3D, currentPosition3D);
			var angle = Vector3D.AngleBetween(this._previousPosition3D, currentPosition3D);
			var delta = new Quaternion(axis, -angle);

			// Get the current orientation from the RotateTransform3D
			var r = this._rotation;
			var q = new Quaternion(this._rotation.Axis, this._rotation.Angle);

			// Compose the delta with the previous orientation
			q *= delta;

			// Write the new orientation back to the Rotation3D
			this._rotation.Axis = q.Axis;
			this._rotation.Angle = q.Angle;

			this._previousPosition3D = currentPosition3D;
		}

		private Vector3D ProjectToTrackball(double width, double height, Point point)
		{
			var x = point.X / (width / 2); // Scale so bounds map to [0,0] - [2,2]
			var y = point.Y / (height / 2);

			x = x - 1; // Translate 0,0 to the center
			y = 1 - y; // Flip so +Y is up instead of down

			var z2 = 1 - x * x - y * y; // z^2 = 1 - x^2 - y^2
			var z = z2 > 0 ? Math.Sqrt(z2) : 0;

			return new Vector3D(x, y, z);
		}

		private void Zoom(Point currentPosition)
		{
			var yDelta = currentPosition.Y - this._previousPosition2D.Y;

			var scale = Math.Exp(yDelta / 100); // e^(yDelta/100) is fairly arbitrary.

			this._scale.ScaleX *= scale;
			this._scale.ScaleY *= scale;
			this._scale.ScaleZ *= scale;
		}

		#region Event Handling
		/// <summary>
		///     The FrameworkElement we listen to for mouse events.
		/// </summary>
		public FrameworkElement EventSource
		{
			get { return this._eventSource; }

			set
			{
				if (this._eventSource != null)
				{
					this._eventSource.MouseDown -= this.OnMouseDown;
					this._eventSource.MouseUp -= this.OnMouseUp;
					this._eventSource.MouseMove -= this.OnMouseMove;
				}

				this._eventSource = value;

				this._eventSource.MouseDown += this.OnMouseDown;
				this._eventSource.MouseUp += this.OnMouseUp;
				this._eventSource.MouseMove += this.OnMouseMove;
			}
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			Mouse.Capture(this.EventSource, CaptureMode.Element);
			this._previousPosition2D = e.GetPosition(this.EventSource);
			this._previousPosition3D = this.ProjectToTrackball(this.EventSource.ActualWidth, this.EventSource.ActualHeight,
			                                                   this._previousPosition2D);
		}

		private void OnMouseUp(object sender, MouseEventArgs e) { Mouse.Capture(this.EventSource, CaptureMode.None); }

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			var currentPosition = e.GetPosition(this.EventSource);

			// Prefer tracking to zooming if both buttons are pressed.
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				this.Track(currentPosition);
			}
			else if (e.RightButton == MouseButtonState.Pressed)
			{
				this.Zoom(currentPosition);
			}

			this._previousPosition2D = currentPosition;
		}
		#endregion Event Handling
	}
}