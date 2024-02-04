using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace Satori.Module.RadzenSample.Migrations.EntityBuilders
{
    public class RadzenSampleEntityBuilder : AuditableBaseEntityBuilder<RadzenSampleEntityBuilder>
    {
        private const string _entityTableName = "SatoriRadzenSample";
        private readonly PrimaryKey<RadzenSampleEntityBuilder> _primaryKey = new("PK_SatoriRadzenSample", x => x.RadzenSampleId);
        private readonly ForeignKey<RadzenSampleEntityBuilder> _moduleForeignKey = new("FK_SatoriRadzenSample_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public RadzenSampleEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override RadzenSampleEntityBuilder BuildTable(ColumnsBuilder table)
        {
            RadzenSampleId = AddAutoIncrementColumn(table,"RadzenSampleId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> RadzenSampleId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
