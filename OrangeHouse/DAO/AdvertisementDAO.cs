using OrangeHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeHouse.DAO
{
    public class AdvertisementDAO
    {
        private ApplicationDbContext db;
        public AdvertisementDAO(ApplicationDbContext applicationDbContext) {
            db = applicationDbContext;
        }

        public List<Advertisement> GetAdvsPass()
            {
                var query = from s in db.Advertisements
                            where s.Pass == 1
                            select s;
                if (query == null)
                {
                    return null;
                }
                return query.ToList();
            }

            public List<Advertisement> GetAdvsUnprocessed()
            {
                var query = from s in db.Advertisements
                            where s.Pass == 0
                            select s;
                if (query == null)
                {
                    return null;
                }
                return query.ToList();
            }

            //add to database
            public void AddAdvertisement(Advertisement advertisement)
            {
            
                db.Advertisements.Add(advertisement);
                db.SaveChanges();
            }
        }


    }
