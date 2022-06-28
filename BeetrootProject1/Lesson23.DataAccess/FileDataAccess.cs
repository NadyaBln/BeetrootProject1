using Lesson23_Contracts;
using System.Collections.Generic;
using System.IO;

namespace Lesson23.DataAccess
{
    public interface IDataAccess
    {
        List<Room> GetAll();
        void WriteAll(List<Room> rooms);
    }

    public class FileDataAccess : IDataAccess
    {
        //file path
        private string filePath = "rooms.file";

        //method returns Contracts
        public List<Room> GetAll()
        {
            using (Stream stream = File.Open(this.filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (List<Room>)binaryFormatter.Deserialize(stream);
            }
        }

        //method writes rooms to file
        public void WriteAll(List<Room> rooms)
        {
            using (Stream stream = File.Open(this.filePath, FileMode.Append))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, rooms);
            }
        }
    }
}
