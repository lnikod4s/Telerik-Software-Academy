namespace DocumentSystem
{
	public abstract class EncryptableDocument : BinaryDocument, IEncryptable
	{
		public bool IsEncrypted { get; protected set; }
		public void Encrypt() { this.IsEncrypted = true; }
		public void Decrypt() { this.IsEncrypted = false; }

		public override string ToString()
		{
			if (this.IsEncrypted)
			{
				return string.Format("{0}[encrypted]", this.GetType().Name);
			}
			else
			{
				return base.ToString();
			}
		}
	}
}