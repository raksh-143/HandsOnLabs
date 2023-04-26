using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings_Mountains
{
    public class MountainsMigrationStrategy:DropCreateDatabaseIfModelChanges<MountainContext>
    {
        protected override void Seed(MountainContext db)
        {
            //Seed data if not already seeded
            var bulgaria = new Country3
            {
                Code = "BG",
                Name = "Bulgaria"
            };
            db.Countries.Add(bulgaria);
            var germany = new Country3
            {
                Code = "DE",
                Name = "Germany"
            };
            db.Countries.Add(germany);

            var rila = new Mountain
            {
                Name = "Rila",
                Countries = { bulgaria }
            };
            db.Mountains.Add(rila);
            var pirin = new Mountain
            {
                Name = "Pirin",
                Countries = { bulgaria }
            };
            db.Mountains.Add(pirin);
            var rhodopes = new Mountain
            {
                Name = "Rhodopes",
                Countries = { bulgaria }
            };

            var musala = new Peak
            {
                Name = "Musala",
                Elevation = 2925,
                Mountain = rila
            };
            db.Peaks.Add(musala);
            var malyovitsa = new Peak
            {
                Name = "Malyovitsa",
                Elevation = 2729,
                Mountain = rila
            };
            db.Peaks.Add(malyovitsa);
            var vihren = new Peak
            {
                Name = "Vihren",
                Elevation = 2914,
                Mountain = pirin
            };
            db.Peaks.Add(vihren);
        }
    }
}
