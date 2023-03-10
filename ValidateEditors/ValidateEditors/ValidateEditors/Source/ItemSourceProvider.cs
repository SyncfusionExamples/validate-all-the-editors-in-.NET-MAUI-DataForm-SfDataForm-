using Syncfusion.Maui.DataForm;

namespace ValidateEditors
{
    public class ItemSourceProvider : IDataFormSourceProvider
    {
        public object GetSource(string sourceName)
        {
            if (sourceName == "State")
            {
                List<string> state = new List<string>() { "TamilNadu", "Kerala", "Gujarat", "Assam" };
                return state;
            }

            if (sourceName == "Country")
            {
                List<string> country = new List<string>() { "USA", "Italy", "India", "Indonesia", "Ireland" };
                return country;
            }

            if (sourceName == "City")
            {
                List<string> city = new List<string>() { "Chennai", "California", "Calabria", "India", "Qatar" };
                return city;
            }

            return new List<string>();
        }
    }
}