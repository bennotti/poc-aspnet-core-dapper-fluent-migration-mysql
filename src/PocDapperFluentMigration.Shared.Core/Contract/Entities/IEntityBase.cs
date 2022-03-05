using System;

namespace PocDapperFluentMigration.Shared.Core.Contract.Entities
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
        DateTime CriadoEm { get; set; }
        DateTime UltimaAlteracaoEm { get; set; }
        DateTime? RemovidoEm { get; set; }
        bool FoiRemovido { get; set; }
    }
}
