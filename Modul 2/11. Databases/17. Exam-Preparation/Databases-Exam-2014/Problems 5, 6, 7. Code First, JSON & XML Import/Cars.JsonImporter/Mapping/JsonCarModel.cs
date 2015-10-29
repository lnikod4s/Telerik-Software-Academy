namespace Cars.JsonImporter.Mapping
{
    using Models;

    public class JsonCarModel
    {
        public short Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public JsonDealerModel Dealer { get; set; }
    }
}