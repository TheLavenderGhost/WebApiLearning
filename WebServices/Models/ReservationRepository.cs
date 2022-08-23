using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models {
    public class ReservationRepository : IReservationRepository {
        private List<Reservation> data = new List<Reservation> {
            new Reservation {ReservationId = 1,  ClientName = "Kowalski", Location = "Londyn"},
            new Reservation {ReservationId = 2,  ClientName = "Nowak", Location = "Nowy Jork"},
            new Reservation {ReservationId = 3,  ClientName = "Bobrowska", Location = "Paryż"},
        };

        private static ReservationRepository repo = new ReservationRepository();
        public static IReservationRepository getRepository() {
            return repo;
        }

        public IEnumerable<Reservation> GetAll() {
            return data;
        }

        public Reservation Get(int id) {
            var matches = data.Where(r => r.ReservationId == id);
            return matches.Count() > 0 ? matches.First() : null;
        }

        public Reservation Add(Reservation item) {
            item.ReservationId = data.Count + 1;
            data.Add(item);
            return item;
        }

        public void Remove(int id) {
            Reservation item = Get(id);
            if (item != null) {
                data.Remove(item);
            }
        }

        public bool Update(Reservation item) {
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null) {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            } else {
                return false;
            }
        }
    }
}