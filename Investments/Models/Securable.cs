namespace Investments
{
	public class Securable
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public Securable BaseSecurable { get; set; }
    }
}