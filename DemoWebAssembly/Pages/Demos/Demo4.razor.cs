namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo4
    {
        public List<string> MaListe { get; set; }

        protected override void OnInitialized()
        {
            MaListe = new List<string>();
            for(int i = 0; i < 50; i++)
            {
                MaListe.Add(Guid.NewGuid().ToString());
            }
        }
    }
}
