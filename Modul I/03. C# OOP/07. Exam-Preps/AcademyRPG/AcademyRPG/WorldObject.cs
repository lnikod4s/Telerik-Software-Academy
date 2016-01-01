﻿namespace AcademyRPG
{
	public abstract class WorldObject : IWorldObject
	{
		public WorldObject(Point position, int owner)
		{
			this.Position = position;
			this.Owner = owner;
			this.HitPoints = 0;
		}

		public int Owner { get; private set; }
		public int HitPoints { get; set; }
		public Point Position { get; protected set; }

		public bool IsDestroyed
		{
			get { return this.HitPoints <= 0; }
		}

		public override string ToString() { return this.GetType().Name; }
	}
}