using HFG.Database;
using HFG.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    public class HighscoreLogic : IHighScoreLogic
    {
        private DrillRepository drillRepository;
        public HighscoreLogic(DrillRepository repo = null)
        {
            if (repo == null)
            {
                this.drillRepository = new DrillRepository(new HFGEntities());
            }
            else
            {
                this.drillRepository = repo;
            }
        }
        public IQueryable<int?> Top5HighScore()
        {
            var q = drillRepository.GetAll().OrderByDescending(x => x.drill_score).Take(5);
            return q.Select(x => x.drill_score);
        }
    }
}
