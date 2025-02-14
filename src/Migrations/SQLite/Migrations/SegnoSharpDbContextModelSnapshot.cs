﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Whitestone.SegnoSharp.Database;

#nullable disable

namespace Whitestone.SegnoSharp.Database.Migrations.SQLite.Migrations
{
    [DbContext(typeof(SegnoSharpDbContext))]
    partial class SegnoSharpDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("NOCASE")
                .HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("AlbumGenre", b =>
                {
                    b.Property<int>("AlbumsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlbumsId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("AlbumGenre");
                });

            modelBuilder.Entity("AlbumPersonGroupPersonRelationPerson", b =>
                {
                    b.Property<int>("AlbumPersonGroupPersonRelationsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlbumPersonGroupPersonRelationsId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("AlbumPersonGroupPersonRelationPerson");
                });

            modelBuilder.Entity("AlbumRecordLabel", b =>
                {
                    b.Property<int>("AlbumsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecordLabelsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlbumsId", "RecordLabelsId");

                    b.HasIndex("RecordLabelsId");

                    b.ToTable("AlbumRecordLabel");
                });

            modelBuilder.Entity("DiscMediaType", b =>
                {
                    b.Property<int>("DiscsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaTypesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DiscsId", "MediaTypesId");

                    b.HasIndex("MediaTypesId");

                    b.ToTable("DiscMediaType");
                });

            modelBuilder.Entity("PersonTrackPersonGroupPersonRelation", b =>
                {
                    b.Property<int>("PersonsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrackPersonGroupPersonRelationsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonsId", "TrackPersonGroupPersonRelationsId");

                    b.HasIndex("TrackPersonGroupPersonRelationsId");

                    b.ToTable("PersonTrackPersonGroupPersonRelation");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Added")
                        .HasColumnType("TEXT");

                    b.Property<string>("CatalogueNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Published")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT COLLATE NOCASE");

                    b.Property<string>("Upc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.AlbumCover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Filesize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId")
                        .IsUnique();

                    b.ToTable("AlbumCovers");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.AlbumCoverData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumCoverId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Data")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("AlbumCoverId")
                        .IsUnique();

                    b.ToTable("AlbumCoversData");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.AlbumPersonGroupPersonRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PersonGroupId");

                    b.ToTable("AlbumPersonGroupsRelations");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Disc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("DiscNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Discs");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT COLLATE NOCASE");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.MediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MediaTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CD",
                            SortOrder = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            Name = "DVD-Audio",
                            SortOrder = (byte)2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Super Audio CD",
                            SortOrder = (byte)3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Digital Download",
                            SortOrder = (byte)4
                        });
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.PersistenceManagerEntry", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.ToTable("PersistenceManagerEntries");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT COLLATE NOCASE");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT COLLATE NOCASE");

                    b.Property<ushort>("Version")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LastName", "FirstName");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.PersonGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<ushort>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PersonGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Artist",
                            SortOrder = (ushort)1,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Artist",
                            SortOrder = (ushort)1,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Composer",
                            SortOrder = (ushort)2,
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Composer",
                            SortOrder = (ushort)2,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.PersonGroupStreamInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IncludeInAutoPlaylist")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IncludeInAutoPlaylist");

                    b.HasIndex("PersonGroupId")
                        .IsUnique();

                    b.ToTable("PersonGroupsStreamInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IncludeInAutoPlaylist = true,
                            PersonGroupId = 1
                        },
                        new
                        {
                            Id = 2,
                            IncludeInAutoPlaylist = true,
                            PersonGroupId = 2
                        });
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.RecordLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("RecordLabels");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.StreamHistory", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Played")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TrackStreamInfoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TrackStreamInfoId");

                    b.ToTable("StreamHistory");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.StreamQueue", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TrackStreamInfoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TrackStreamInfoId");

                    b.ToTable("StreamQueue");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscId")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<ushort>("TrackNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DiscId");

                    b.HasIndex("Title");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.TrackGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscId")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("GroupBeforeTrackNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiscId");

                    b.ToTable("TrackGroups");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.TrackPersonGroupPersonRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PersonGroupId");

                    b.ToTable("TrackPersonGroupsRelations");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.TrackStreamInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IncludeInAutoPlaylist")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastPlayed")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrackId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TrackId")
                        .IsUnique();

                    b.HasIndex("IncludeInAutoPlaylist", "LastPlayed", "PlayCount");

                    b.ToTable("TrackStreamInfos");
                });

            modelBuilder.Entity("AlbumGenre", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumPersonGroupPersonRelationPerson", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.AlbumPersonGroupPersonRelation", null)
                        .WithMany()
                        .HasForeignKey("AlbumPersonGroupPersonRelationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumRecordLabel", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whitestone.SegnoSharp.Database.Models.RecordLabel", null)
                        .WithMany()
                        .HasForeignKey("RecordLabelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscMediaType", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Disc", null)
                        .WithMany()
                        .HasForeignKey("DiscsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whitestone.SegnoSharp.Database.Models.MediaType", null)
                        .WithMany()
                        .HasForeignKey("MediaTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonTrackPersonGroupPersonRelation", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whitestone.SegnoSharp.Database.Models.TrackPersonGroupPersonRelation", null)
                        .WithMany()
                        .HasForeignKey("TrackPersonGroupPersonRelationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.AlbumCover", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Album", "Album")
                        .WithOne("AlbumCover")
                        .HasForeignKey("Whitestone.SegnoSharp.Database.Models.AlbumCover", "AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.AlbumCoverData", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.AlbumCover", "AlbumCover")
                        .WithOne("AlbumCoverData")
                        .HasForeignKey("Whitestone.SegnoSharp.Database.Models.AlbumCoverData", "AlbumCoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlbumCover");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.AlbumPersonGroupPersonRelation", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Album", "Parent")
                        .WithMany("AlbumPersonGroupPersonRelations")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whitestone.SegnoSharp.Database.Models.PersonGroup", "PersonGroup")
                        .WithMany("AlbumPersonGroupPersonRelations")
                        .HasForeignKey("PersonGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("PersonGroup");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Disc", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Album", "Album")
                        .WithMany("Discs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.PersonGroupStreamInfo", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.PersonGroup", "PersonGroup")
                        .WithOne("PersonGroupStreamInfo")
                        .HasForeignKey("Whitestone.SegnoSharp.Database.Models.PersonGroupStreamInfo", "PersonGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonGroup");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.StreamHistory", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.TrackStreamInfo", "TrackStreamInfo")
                        .WithMany("StreamHistory")
                        .HasForeignKey("TrackStreamInfoId");

                    b.Navigation("TrackStreamInfo");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.StreamQueue", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.TrackStreamInfo", "TrackStreamInfo")
                        .WithMany("StreamQueue")
                        .HasForeignKey("TrackStreamInfoId");

                    b.Navigation("TrackStreamInfo");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Track", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Disc", "Disc")
                        .WithMany("Tracks")
                        .HasForeignKey("DiscId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disc");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.TrackGroup", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Disc", "Disc")
                        .WithMany("TrackGroups")
                        .HasForeignKey("DiscId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disc");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.TrackPersonGroupPersonRelation", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Track", "Parent")
                        .WithMany("TrackPersonGroupPersonRelations")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whitestone.SegnoSharp.Database.Models.PersonGroup", "PersonGroup")
                        .WithMany("TrackPersonGroupPersonRelations")
                        .HasForeignKey("PersonGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("PersonGroup");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.TrackStreamInfo", b =>
                {
                    b.HasOne("Whitestone.SegnoSharp.Database.Models.Track", "Track")
                        .WithOne("TrackStreamInfo")
                        .HasForeignKey("Whitestone.SegnoSharp.Database.Models.TrackStreamInfo", "TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Album", b =>
                {
                    b.Navigation("AlbumCover");

                    b.Navigation("AlbumPersonGroupPersonRelations");

                    b.Navigation("Discs");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.AlbumCover", b =>
                {
                    b.Navigation("AlbumCoverData");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Disc", b =>
                {
                    b.Navigation("TrackGroups");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.PersonGroup", b =>
                {
                    b.Navigation("AlbumPersonGroupPersonRelations");

                    b.Navigation("PersonGroupStreamInfo");

                    b.Navigation("TrackPersonGroupPersonRelations");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.Track", b =>
                {
                    b.Navigation("TrackPersonGroupPersonRelations");

                    b.Navigation("TrackStreamInfo");
                });

            modelBuilder.Entity("Whitestone.SegnoSharp.Database.Models.TrackStreamInfo", b =>
                {
                    b.Navigation("StreamHistory");

                    b.Navigation("StreamQueue");
                });
#pragma warning restore 612, 618
        }
    }
}
