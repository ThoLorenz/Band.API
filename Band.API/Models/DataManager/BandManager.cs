using System;
using Band.API.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.Language;

namespace Band.API.Models.DataManager
    {
    public class BandManager : IDataRepository<Band, int>
        {

        BandContext _context;
        public BandManager(BandContext context)
            {
            _context = context;
            }

        public int Add(Band band)
            {
            _context.Bands.Add(band);
            int id = _context.SaveChanges();
            return id;
            }

        public int Delete(int id)
            {
            var band = _context.Bands.FirstOrDefault(b => b.Id == id);
            if (band != null)
                {
                _context.Bands.Remove(band);
                _context.SaveChanges();
                }
            return id;
            }

        public Band Get(int id)
            {
            return _context.Bands.FirstOrDefault(b => b.Id == id);
            }

        public IEnumerable<Band> GetAll()
            {
            return _context.Bands.ToList();
            }

        public int Update(int id, Band b)
            {

            var band = _context.Bands.Find(id);
            if (band != null)
                {
                band.Name = b.Name;
                band.Genre = b.Genre;
                _context.SaveChanges();
                }
            return id;
            }
        }
    }
