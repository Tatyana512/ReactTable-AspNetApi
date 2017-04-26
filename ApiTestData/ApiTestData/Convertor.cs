namespace ApiTestData
{
    public class Convertor
    {       
        public static Models.Item ConvertBackClass(Models.ItemToSave mongoitem)
        {
            return new Models.Item(mongoitem.GuidId, mongoitem.Name, mongoitem.Count, mongoitem.DateTime);
        }
    }
}