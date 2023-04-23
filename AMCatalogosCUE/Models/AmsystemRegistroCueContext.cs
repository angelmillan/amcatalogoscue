using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AMCatalogosCUE.Models;

public partial class AmsystemRegistroCueContext : DbContext
{
    public AmsystemRegistroCueContext()
    {
    }

    public AmsystemRegistroCueContext(DbContextOptions<AmsystemRegistroCueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActividadAgrarium> ActividadAgraria { get; set; }

    public virtual DbSet<ActividadSecundariaNoAgrarium> ActividadSecundariaNoAgraria { get; set; }

    public virtual DbSet<ActividadSobreCubiertum> ActividadSobreCubierta { get; set; }

    public virtual DbSet<Ad> Ads { get; set; }

    public virtual DbSet<AgrupacionesGip> AgrupacionesGips { get; set; }

    public virtual DbSet<Aprovechamiento> Aprovechamientos { get; set; }

    public virtual DbSet<AsocacionesProteccionRiesgoErosion> AsocacionesProteccionRiesgoErosions { get; set; }

    public virtual DbSet<AsociacionRaza> AsociacionRazas { get; set; }

    public virtual DbSet<AutorizadasAlgodon> AutorizadasAlgodons { get; set; }

    public virtual DbSet<BuenasPracticasFertilizante> BuenasPracticasFertilizantes { get; set; }

    public virtual DbSet<BuenasPracticasRiego> BuenasPracticasRiegos { get; set; }

    public virtual DbSet<CapacitacionProfesional> CapacitacionProfesionals { get; set; }

    public virtual DbSet<CausasBaja> CausasBajas { get; set; }

    public virtual DbSet<CertificacionProdEcologica> CertificacionProdEcologicas { get; set; }

    public virtual DbSet<ClasificacionExplotacion> ClasificacionExplotacions { get; set; }

    public virtual DbSet<ComunidadesRegante> ComunidadesRegantes { get; set; }

    public virtual DbSet<Desmotadora> Desmotadoras { get; set; }

    public virtual DbSet<DestinoCultivo> DestinoCultivos { get; set; }

    public virtual DbSet<DestinoRestoVegetal> DestinoRestoVegetals { get; set; }

    public virtual DbSet<DetalleActividadAgrarium> DetalleActividadAgraria { get; set; }

    public virtual DbSet<EdificacionesInstalacione> EdificacionesInstalaciones { get; set; }

    public virtual DbSet<EficaciaTratamiento> EficaciaTratamientos { get; set; }

    public virtual DbSet<EmpresaProdSemillasCertific> EmpresaProdSemillasCertifics { get; set; }

    public virtual DbSet<Enfermedade> Enfermedades { get; set; }

    public virtual DbSet<EntidadAsesoramiento> EntidadAsesoramientos { get; set; }

    public virtual DbSet<EntidadCertificacion> EntidadCertificacions { get; set; }

    public virtual DbSet<FinalidadCosecha> FinalidadCosechas { get; set; }

    public virtual DbSet<HerramientasDigitale> HerramientasDigitales { get; set; }

    public virtual DbSet<JustificacionActuacion> JustificacionActuacions { get; set; }

    public virtual DbSet<MalasHierba> MalasHierbas { get; set; }

    public virtual DbSet<MaterialAnalizado> MaterialAnalizados { get; set; }

    public virtual DbSet<MaterialFertilizante> MaterialFertilizantes { get; set; }

    public virtual DbSet<MaterialVegetalReproduccion> MaterialVegetalReproduccions { get; set; }

    public virtual DbSet<MedidaPreventivaCultural> MedidaPreventivaCulturals { get; set; }

    public virtual DbSet<MetodoAplicacionFertilizante> MetodoAplicacionFertilizantes { get; set; }

    public virtual DbSet<Opfh> Opfhs { get; set; }

    public virtual DbSet<OrigenAguaRiego> OrigenAguaRiegos { get; set; }

    public virtual DbSet<Portainjerto> Portainjertos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoVariedadEspecieTipo> ProductoVariedadEspecieTipos { get; set; }

    public virtual DbSet<ProductoVegetal> ProductoVegetals { get; set; }

    public virtual DbSet<RegimenTenencium> RegimenTenencia { get; set; }

    public virtual DbSet<RegimenesCalidad> RegimenesCalidads { get; set; }

    public virtual DbSet<ReguladoresCrecimientoyOtro> ReguladoresCrecimientoyOtros { get; set; }

    public virtual DbSet<Senp> Senps { get; set; }

    public virtual DbSet<SistemaConduccion> SistemaConduccions { get; set; }

    public virtual DbSet<SistemaCultivo> SistemaCultivos { get; set; }

    public virtual DbSet<SistemaExplotacion> SistemaExplotacions { get; set; }

    public virtual DbSet<SistemaRiego> SistemaRiegos { get; set; }

    public virtual DbSet<SubtanciasActivasAnalisi> SubtanciasActivasAnalises { get; set; }

    public virtual DbSet<TipoAgricultor> TipoAgricultors { get; set; }

    public virtual DbSet<TipoAnalisi> TipoAnalises { get; set; }

    public virtual DbSet<TipoAyudaVignedo> TipoAyudaVignedos { get; set; }

    public virtual DbSet<TipoCoberturaSuelo> TipoCoberturaSuelos { get; set; }

    public virtual DbSet<TipoEntidadAsociacion> TipoEntidadAsociacions { get; set; }

    public virtual DbSet<TipoFertilizacion> TipoFertilizacions { get; set; }

    public virtual DbSet<TipoMedidaFitosanitarium> TipoMedidaFitosanitaria { get; set; }

    public virtual DbSet<TipoSuperfPlantadaUvaVinificable> TipoSuperfPlantadaUvaVinificables { get; set; }

    public virtual DbSet<TipoSuperficiePotencialUvaVino> TipoSuperficiePotencialUvaVinos { get; set; }

    public virtual DbSet<TipoTitular> TipoTitulars { get; set; }

    public virtual DbSet<TipoaAutorizDchoOrigenVignedo> TipoaAutorizDchoOrigenVignedos { get; set; }

    public virtual DbSet<UnidadesMedidum> UnidadesMedida { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=beta.amsystem.es;Initial Catalog=AMSystemRegistroCUE;Persist Security Info=True;User ID=sa;Password=Mk810osd12345;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActividadAgrarium>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Activida__4AA385605E752D14");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.ActividadAgrariaDescripcion).HasMaxLength(255);
        });

        modelBuilder.Entity<ActividadSecundariaNoAgrarium>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Activida__4AA385606C891EF9");

            entity.Property(e => e.CodigoSiex)
                .HasMaxLength(50)
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
        });

        modelBuilder.Entity<ActividadSobreCubiertum>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Activida__4AA3856001FD84DA");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.ActividadSobreCubiertaDescripcion).HasMaxLength(255);
        });

        modelBuilder.Entity<Ad>(entity =>
        {
            entity.HasKey(e => e.CodigoAsociacion).HasName("PK__ADS__455584860CA1B618");

            entity.ToTable("ADS");

            entity.Property(e => e.CodigoAsociacion).HasMaxLength(50);
            entity.Property(e => e.Ca)
                .HasMaxLength(255)
                .HasColumnName("CA");
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif)
                .HasMaxLength(255)
                .HasColumnName("NIF");
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<AgrupacionesGip>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AgrupacionesGIP");

            entity.Property(e => e.Ca)
                .HasMaxLength(255)
                .HasColumnName("CA");
            entity.Property(e => e.CodigoAsociacion).HasMaxLength(50);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif)
                .HasMaxLength(9)
                .HasColumnName("NIF");
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<Aprovechamiento>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Aprovech__4AA38560C7EF5BAA");

            entity.ToTable("Aprovechamiento");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Aprovechamiento1)
                .HasMaxLength(255)
                .HasColumnName("Aprovechamiento");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<AsocacionesProteccionRiesgoErosion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AsocacionesProteccionRiesgoErosion");

            entity.Property(e => e.AutoridadCompetente).HasMaxLength(255);
            entity.Property(e => e.CodigoAsociacion).HasMaxLength(255);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif)
                .HasMaxLength(255)
                .HasColumnName("NIF");
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<AsociacionRaza>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AutoridadCompetente).HasMaxLength(255);
            entity.Property(e => e.CodigoAsociacion).HasMaxLength(255);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif)
                .HasMaxLength(255)
                .HasColumnName("NIF");
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<AutorizadasAlgodon>(entity =>
        {
            entity.HasKey(e => e.CodigoAsociacion).HasName("PK__Autoriza__45558486F325FC2A");

            entity.ToTable("AutorizadasAlgodon");

            entity.Property(e => e.CodigoAsociacion).ValueGeneratedNever();
            entity.Property(e => e.AutoridadCompetente).HasMaxLength(255);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif)
                .HasMaxLength(255)
                .HasColumnName("NIF");
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<BuenasPracticasFertilizante>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__BuenasPr__4AA38560C4A08116");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.BuenasPracticasFertilizantes).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<BuenasPracticasRiego>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__BuenasPr__4AA3856088A9862C");

            entity.ToTable("BuenasPracticasRiego");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.BuenasPracticasRiego1).HasColumnName("BuenasPracticasRiego");
        });

        modelBuilder.Entity<CapacitacionProfesional>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Capacita__4AA38560EA439482");

            entity.ToTable("CapacitacionProfesional");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.CapacitacionProfesional1)
                .HasMaxLength(255)
                .HasColumnName("CapacitacionProfesional");
        });

        modelBuilder.Entity<CausasBaja>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__CausasBa__4AA3856099E75D96");

            entity.ToTable("CausasBaja");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Tipo).HasMaxLength(255);
        });

        modelBuilder.Entity<CertificacionProdEcologica>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Certific__4AA385606BFCF13A");

            entity.ToTable("CertificacionProdEcologica");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
        });

        modelBuilder.Entity<ClasificacionExplotacion>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Clasific__4AA385603C32FEEF");

            entity.ToTable("ClasificacionExplotacion");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
        });

        modelBuilder.Entity<ComunidadesRegante>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Comunida__4AA38560726F5FCE");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Clase).HasMaxLength(255);
            entity.Property(e => e.CuaceOacuiferoToma)
                .HasMaxLength(255)
                .HasColumnName("CuaceOAcuiferoToma");
            entity.Property(e => e.CudalLS2)
                .HasMaxLength(255)
                .HasColumnName("Cudal(l/s)2");
            entity.Property(e => e.Municipio).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Organismo).HasMaxLength(255);
            entity.Property(e => e.Provincia).HasMaxLength(255);
            entity.Property(e => e.SuperficieHa)
                .HasMaxLength(255)
                .HasColumnName("Superficie(ha)");
            entity.Property(e => e.Uso).HasMaxLength(255);
        });

        modelBuilder.Entity<Desmotadora>(entity =>
        {
            entity.HasKey(e => e.CodigoAsociacion).HasName("PK__Desmotad__455584863A17759E");

            entity.ToTable("Desmotadora");

            entity.Property(e => e.CodigoAsociacion).ValueGeneratedNever();
            entity.Property(e => e.AutoridadCompetente).HasMaxLength(255);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif).HasMaxLength(255);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<DestinoCultivo>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__DestinoC__4AA38560F055B143");

            entity.ToTable("DestinoCultivo");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.DestinoCultivo1)
                .HasMaxLength(255)
                .HasColumnName("DestinoCultivo");
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<DestinoRestoVegetal>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__DestinoR__4AA385606C6EA4AE");

            entity.ToTable("DestinoRestoVegetal");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.DestinoRestoVegetal1)
                .HasMaxLength(255)
                .HasColumnName("DestinoRestoVegetal");
        });

        modelBuilder.Entity<DetalleActividadAgrarium>(entity =>
        {
            entity.HasKey(e => e.SubCodigo).HasName("PK__DetalleA__8F1B7985A2F36F96");

            entity.Property(e => e.SubCodigo).ValueGeneratedNever();
            entity.Property(e => e.ActividadAgraria).HasMaxLength(255);
            entity.Property(e => e.Ambito).HasMaxLength(255);
            entity.Property(e => e.DetalleActividadAgraria).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<EdificacionesInstalacione>(entity =>
        {
            entity.HasKey(e => e.SubCodigo).HasName("PK__Edificac__8F1B7985A2544AB0");

            entity.Property(e => e.SubCodigo).ValueGeneratedNever();
            entity.Property(e => e.EdificacionInstalacion).HasMaxLength(255);
            entity.Property(e => e.Tipologia).HasMaxLength(255);
        });

        modelBuilder.Entity<EficaciaTratamiento>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Eficacia__4AA3856045D0362D");

            entity.ToTable("EficaciaTratamiento");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.EficaciaTratamiento1)
                .HasMaxLength(255)
                .HasColumnName("EficaciaTratamiento");
        });

        modelBuilder.Entity<EmpresaProdSemillasCertific>(entity =>
        {
            entity.HasKey(e => e.CodigoAsociacion).HasName("PK__EmpresaP__45558486F11EDCED");

            entity.ToTable("EmpresaProdSemillasCertific");

            entity.Property(e => e.CodigoAsociacion).ValueGeneratedNever();
            entity.Property(e => e.AutoridadCompetente).HasMaxLength(255);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif).HasMaxLength(255);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<Enfermedade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enfermed__3214EC2700D6BAFA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Categoría).HasMaxLength(50);
            entity.Property(e => e.Codigo).HasMaxLength(12);
            entity.Property(e => e.EppoCd)
                .HasMaxLength(50)
                .HasColumnName("EPPO cd");
            entity.Property(e => e.NombreCientifico).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<EntidadAsesoramiento>(entity =>
        {
            entity.HasKey(e => e.CodigoAsociacion).HasName("PK__EntidadA__4555848669E0B9F6");

            entity.ToTable("EntidadAsesoramiento");

            entity.Property(e => e.CodigoAsociacion).ValueGeneratedNever();
            entity.Property(e => e.Ca)
                .HasMaxLength(255)
                .HasColumnName("CA");
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif)
                .HasMaxLength(255)
                .HasColumnName("NIF");
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<EntidadCertificacion>(entity =>
        {
            entity.HasKey(e => e.CodigoAsociacion).HasName("PK__EntidadC__45558486C2FB9018");

            entity.ToTable("EntidadCertificacion");

            entity.Property(e => e.CodigoAsociacion).HasMaxLength(50);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif).HasMaxLength(255);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
            entity.Property(e => e.ZonaControl).HasMaxLength(255);
        });

        modelBuilder.Entity<FinalidadCosecha>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Finalida__4AA38560C0F24D4D");

            entity.ToTable("FinalidadCosecha");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.DeclaracionCosechaProduccion).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<HerramientasDigitale>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CodigoSiex).HasColumnName("CodigoSIEX");
            entity.Property(e => e.Entidad).HasMaxLength(255);
            entity.Property(e => e.NombreComercialHeramienta).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
            entity.Property(e => e.Sector).HasMaxLength(255);
            entity.Property(e => e.SubSector).HasMaxLength(255);
            entity.Property(e => e.TecnologiaFuncionalidad).HasMaxLength(255);
        });

        modelBuilder.Entity<JustificacionActuacion>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Justific__4AA38560B32A3467");

            entity.ToTable("JustificacionActuacion");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Justificacion).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<MalasHierba>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__MalasHie__06370DAD592028A6");

            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.Categoria).HasMaxLength(255);
            entity.Property(e => e.Eppocd)
                .HasMaxLength(255)
                .HasColumnName("EPPOcd");
            entity.Property(e => e.NombreCientifico).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<MaterialAnalizado>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Material__4AA3856045800316");

            entity.ToTable("MaterialAnalizado");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.MaterialAnalizado1)
                .HasMaxLength(255)
                .HasColumnName("MaterialAnalizado");
        });

        modelBuilder.Entity<MaterialFertilizante>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Material__4AA385607693C4EB");

            entity.ToTable("MaterialFertilizante");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.CamposRegistrar).HasMaxLength(255);
            entity.Property(e => e.TipoMaterial).HasMaxLength(255);
        });

        modelBuilder.Entity<MaterialVegetalReproduccion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MaterialVegetalReproduccion");

            entity.Property(e => e.DetalleTipo).HasMaxLength(255);
            entity.Property(e => e.TipoMaterialVegetalReproduccion).HasMaxLength(255);
        });

        modelBuilder.Entity<MedidaPreventivaCultural>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__MedidaPr__4AA38560F320F9A5");

            entity.ToTable("MedidaPreventivaCultural");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Medida).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<MetodoAplicacionFertilizante>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__MetodoAp__42AE702A383EB2A2");

            entity.ToTable("MetodoAplicacionFertilizante");

            entity.Property(e => e.CodigoSiex).ValueGeneratedNever();
            entity.Property(e => e.MetodoFertilizacion).HasMaxLength(255);
        });

        modelBuilder.Entity<Opfh>(entity =>
        {
            entity.HasKey(e => e.CodigoAsociacion).HasName("PK__OPFH__45558486291F1363");

            entity.ToTable("OPFH");

            entity.Property(e => e.CodigoAsociacion).HasMaxLength(50);
            entity.Property(e => e.AutoridadCompetente).HasMaxLength(255);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Nif).HasMaxLength(50);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
        });

        modelBuilder.Entity<OrigenAguaRiego>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__OrigenAg__4AA385605BBDEB64");

            entity.ToTable("OrigenAguaRiego");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Observaciones).HasMaxLength(255);
            entity.Property(e => e.OrigenAguaRiego1)
                .HasMaxLength(255)
                .HasColumnName("OrigenAguaRiego");
        });

        modelBuilder.Entity<Portainjerto>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Portainj__4AA38560D7DE81EF");

            entity.ToTable("Portainjerto");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Definicion).HasMaxLength(255);
            entity.Property(e => e.PortaInjerto1)
                .HasMaxLength(255)
                .HasColumnName("PortaInjerto");
            entity.Property(e => e.Sinonimo).HasMaxLength(255);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Producto__06370DADABC72720");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Aromatico).HasMaxLength(255);
            entity.Property(e => e.CultivosPermanentes).HasMaxLength(255);
            entity.Property(e => e.Energetico).HasMaxLength(255);
            entity.Property(e => e.EspeciesMejorantes).HasMaxLength(255);
            entity.Property(e => e.ForestalCicloCorto).HasMaxLength(255);
            entity.Property(e => e.Forestales).HasMaxLength(255);
            entity.Property(e => e.Frutal).HasMaxLength(255);
            entity.Property(e => e.Horticola).HasMaxLength(255);
            entity.Property(e => e.Leñosos).HasMaxLength(255);
            entity.Property(e => e.Nuevo2023).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
            entity.Property(e => e.PastosPermanentes).HasMaxLength(255);
            entity.Property(e => e.ProductoSiex)
                .HasMaxLength(255)
                .HasColumnName("ProductoSIEX");
            entity.Property(e => e.SiembraDirecta).HasMaxLength(255);
            entity.Property(e => e.TierrasCultivo).HasMaxLength(255);
        });

        modelBuilder.Entity<ProductoVariedadEspecieTipo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductoVariedadEspecieTipo");

            entity.Property(e => e.Observaciones).HasMaxLength(255);
            entity.Property(e => e.Producto).HasMaxLength(255);
            entity.Property(e => e.VariedadEspecieTipo).HasMaxLength(255);
        });

        modelBuilder.Entity<ProductoVegetal>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Producto__06370DAD9452333E");

            entity.ToTable("ProductoVegetal");

            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.CodigoSiex)
                .HasMaxLength(255)
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.ObservacionesTragsaTec).HasMaxLength(255);
            entity.Property(e => e.Producto).HasMaxLength(255);
            entity.Property(e => e.ProductoSiex)
                .HasMaxLength(255)
                .HasColumnName("ProductoSIEX");
        });

        modelBuilder.Entity<RegimenTenencium>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__RegimenT__4AA38560B2BCE448");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.RegimenTenecia).HasMaxLength(255);
        });

        modelBuilder.Entity<RegimenesCalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RegimenesCalidad");

            entity.Property(e => e.AmbitoTerritorial).HasMaxLength(255);
            entity.Property(e => e.Categoria).HasMaxLength(255);
            entity.Property(e => e.Clase).HasMaxLength(255);
            entity.Property(e => e.Dgcexplotacion)
                .HasMaxLength(255)
                .HasColumnName("DGCExplotacion");
            entity.Property(e => e.IdIgCcaa)
                .HasMaxLength(255)
                .HasColumnName("Id_IG_CCAA");
            entity.Property(e => e.IdIigg).HasColumnName("IdIIGG");
            entity.Property(e => e.IdTipoIg).HasColumnName("IdTipoIG");
            entity.Property(e => e.IgCcaa)
                .HasMaxLength(255)
                .HasColumnName("IG_CCAA");
            entity.Property(e => e.IiggnombreComercial)
                .HasMaxLength(255)
                .HasColumnName("IIGGNombreComercial");
            entity.Property(e => e.IneCa)
                .HasMaxLength(255)
                .HasColumnName("INE_CA");
            entity.Property(e => e.InecodigoCa)
                .HasMaxLength(255)
                .HasColumnName("INECodigoCA");
            entity.Property(e => e.InecodigoProvincia)
                .HasMaxLength(255)
                .HasColumnName("INECodigoProvincia");
            entity.Property(e => e.Ineprovincia)
                .HasMaxLength(255)
                .HasColumnName("INEProvincia");
            entity.Property(e => e.NumeroExpedienteUe)
                .HasMaxLength(255)
                .HasColumnName("NumeroExpedienteUE");
            entity.Property(e => e.SubClase).HasMaxLength(255);
            entity.Property(e => e.TipoIigg)
                .HasMaxLength(255)
                .HasColumnName("TipoIIGG");
        });

        modelBuilder.Entity<ReguladoresCrecimientoyOtro>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Regulado__06370DAD614A3516");

            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.Categoria).HasMaxLength(255);
            entity.Property(e => e.Eppocd)
                .HasMaxLength(255)
                .HasColumnName("EPPOcd");
            entity.Property(e => e.NombreCientifico).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
        });

        modelBuilder.Entity<Senp>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__SENP__4AA3856064E33789");

            entity.ToTable("SENP");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Bcam8)
                .HasMaxLength(255)
                .HasColumnName("BCAM8");
            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.Delimitacion).HasMaxLength(255);
            entity.Property(e => e.Edb)
                .HasMaxLength(255)
                .HasColumnName("EDB");
            entity.Property(e => e.Eepp)
                .HasMaxLength(255)
                .HasColumnName("EEPP");
            entity.Property(e => e.Ess)
                .HasMaxLength(255)
                .HasColumnName("ESS");
            entity.Property(e => e.FactorConversion).HasMaxLength(255);
            entity.Property(e => e.Obsevaciones).HasMaxLength(255);
            entity.Property(e => e.Tipo).HasMaxLength(255);
        });

        modelBuilder.Entity<SistemaConduccion>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__SistemaC__4AA385603B06F86F");

            entity.ToTable("SistemaConduccion");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.SistemaConduccion1)
                .HasMaxLength(255)
                .HasColumnName("SistemaConduccion");
        });

        modelBuilder.Entity<SistemaCultivo>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__SistemaC__4AA38560D1EA5508");

            entity.ToTable("SistemaCultivo");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Observaciones).HasMaxLength(255);
            entity.Property(e => e.SistemaCultivo1)
                .HasMaxLength(255)
                .HasColumnName("SistemaCultivo");
        });

        modelBuilder.Entity<SistemaExplotacion>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__SistemaE__4AA3856004E4DAA6");

            entity.ToTable("SistemaExplotacion");

            entity.Property(e => e.CodigoSiex)
                .HasMaxLength(2)
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.SistemaExplotacion1)
                .HasMaxLength(255)
                .HasColumnName("SistemaExplotacion");
        });

        modelBuilder.Entity<SistemaRiego>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__SistemaR__4AA385605E2C8521");

            entity.ToTable("SistemaRiego");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.SistemaRiego1)
                .HasMaxLength(255)
                .HasColumnName("SistemaRiego");
        });

        modelBuilder.Entity<SubtanciasActivasAnalisi>(entity =>
        {
            entity.HasKey(e => e.ActiveSubstanceId).HasName("PK__Subtanci__AAD6551931D567E0");

            entity.ToTable("SubtanciasActivasAnalisis");

            entity.Property(e => e.ActiveSubstanceId).ValueGeneratedNever();
            entity.Property(e => e.Aaoel)
                .HasMaxLength(255)
                .HasColumnName("AAOEL");
            entity.Property(e => e.Adi)
                .HasMaxLength(255)
                .HasColumnName("ADI");
            entity.Property(e => e.Aoel)
                .HasMaxLength(255)
                .HasColumnName("AOEL");
            entity.Property(e => e.ArfD)
                .HasMaxLength(255)
                .HasColumnName("ARfD");
            entity.Property(e => e.AssesRisk).HasMaxLength(255);
            entity.Property(e => e.Authorised).HasMaxLength(255);
            entity.Property(e => e.BasicSustande).HasMaxLength(255);
            entity.Property(e => e.CandidateSustitution).HasMaxLength(255);
            entity.Property(e => e.Clasification).HasMaxLength(255);
            entity.Property(e => e.CoRms)
                .HasMaxLength(255)
                .HasColumnName("CoRMS");
            entity.Property(e => e.DateAproval).HasMaxLength(255);
            entity.Property(e => e.ExpirationDate).HasMaxLength(255);
            entity.Property(e => e.Legislation).HasMaxLength(255);
            entity.Property(e => e.LowRisk).HasMaxLength(255);
            entity.Property(e => e.Other).HasMaxLength(255);
            entity.Property(e => e.Reg3962005)
                .HasMaxLength(255)
                .HasColumnName("Reg396/2005");
            entity.Property(e => e.Remak6).HasMaxLength(255);
            entity.Property(e => e.Remark1).HasMaxLength(255);
            entity.Property(e => e.Remark2).HasMaxLength(255);
            entity.Property(e => e.Remark3).HasMaxLength(255);
            entity.Property(e => e.Remark4).HasMaxLength(255);
            entity.Property(e => e.Remarks5).HasMaxLength(255);
            entity.Property(e => e.Rmd)
                .HasMaxLength(255)
                .HasColumnName("RMD");
            entity.Property(e => e.SouerceYear5).HasMaxLength(255);
            entity.Property(e => e.SourceYear).HasMaxLength(255);
            entity.Property(e => e.SourceYear2).HasMaxLength(255);
            entity.Property(e => e.SourceYear3).HasMaxLength(255);
            entity.Property(e => e.SourceYear4).HasMaxLength(255);
            entity.Property(e => e.StatusUnderReg).HasMaxLength(255);
            entity.Property(e => e.Substance).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoAgricultor>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoAgri__4AA385608193FFBC");

            entity.ToTable("TipoAgricultor");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.TipoAgricultor1)
                .HasMaxLength(255)
                .HasColumnName("TipoAgricultor");
        });

        modelBuilder.Entity<TipoAnalisi>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoAnal__4AA38560F9FFCF55");

            entity.ToTable("TipoAnalisis");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.TipoAnalisis).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoAyudaVignedo>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoAyud__4AA385603B5477A9");

            entity.ToTable("TipoAyudaVignedo");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.TipoAyudaViticultivo).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoCoberturaSuelo>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoCobe__4AA38560390F16AD");

            entity.ToTable("TipoCoberturaSuelo");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.TipoCoberturaSuelo1)
                .HasMaxLength(255)
                .HasColumnName("TipoCoberturaSuelo");
        });

        modelBuilder.Entity<TipoEntidadAsociacion>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoEnti__4AA38560C6274E05");

            entity.ToTable("TipoEntidadAsociacion");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.TipoAsociacion).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoFertilizacion>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoFert__4AA385607B31037A");

            entity.ToTable("TipoFertilizacion");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.TipoFertilizacion1)
                .HasMaxLength(255)
                .HasColumnName("TipoFertilizacion");
        });

        modelBuilder.Entity<TipoMedidaFitosanitarium>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoMedi__4AA38560A14F4C2C");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.TipoMedida).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoSuperfPlantadaUvaVinificable>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoSupe__4AA38560CC4F08D0");

            entity.ToTable("TipoSuperfPlantadaUvaVinificable");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.TipoSuperficiePlantadaUvaVino).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoSuperficiePotencialUvaVino>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoSupe__4AA385605DCF4F4D");

            entity.ToTable("TipoSuperficiePotencialUvaVino");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoTitular>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoTitu__4AA38560AEE7CDC2");

            entity.ToTable("TipoTitular");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.FormaJuridica).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoaAutorizDchoOrigenVignedo>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__TipoaAut__4AA3856055CDA1A4");

            entity.ToTable("TipoaAutorizDchoOrigenVignedo");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.AutorizacionDerecho).HasMaxLength(255);
        });

        modelBuilder.Entity<UnidadesMedidum>(entity =>
        {
            entity.HasKey(e => e.CodigoSiex).HasName("PK__Unidades__4AA38560B0C66706");

            entity.Property(e => e.CodigoSiex)
                .ValueGeneratedNever()
                .HasColumnName("CodigoSIEX");
            entity.Property(e => e.UnidadesMedida).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
