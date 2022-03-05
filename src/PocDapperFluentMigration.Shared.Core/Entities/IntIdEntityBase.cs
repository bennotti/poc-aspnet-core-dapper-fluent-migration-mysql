using PocDapperFluentMigration.Shared.Core.Contract.Entities;
using System;

namespace PocDapperFluentMigration.Shared.Core.Entities
{
    public class IntIdEntityBase : IEntityBase<int>
    {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime UltimaAlteracaoEm { get; set; }
        public DateTime? RemovidoEm { get; set; }
        public bool FoiRemovido { get; set; }
        protected IntIdEntityBase()
        {
            FoiRemovido = false;
            CriadoEm = DateTime.UtcNow;
        }
    }
}
