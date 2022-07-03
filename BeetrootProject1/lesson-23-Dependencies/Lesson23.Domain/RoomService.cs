using Lesson23.Contracts;
using Lesson23.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson23.Domain
{
    public class RoomService
    {
        //use interface to meet SOLID 
        private readonly IDataAccess _dataAccess;
        public RoomService()
        {
            this._dataAccess = new FileDataAccess();
        }

        public RoomService(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        //returns Rooms list
        public List<Room> GetAll()
        {
            return this._dataAccess.GetAll();
        }

        public void WriteAll(List<Room> rooms)
        {
            this._dataAccess.WriteAll(rooms);
        }

        public bool IsBooked(Room room, DateTime time)
        {
            return room.Meetings.Select(x => x.Date).Any(x => x == time);
        }
    }
}
