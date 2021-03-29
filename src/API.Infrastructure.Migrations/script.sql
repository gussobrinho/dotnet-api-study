/* VersionMigration migrating ================================================ */

/* Beginning Transaction */
/* CreateTable VersionInfo */
CREATE TABLE "public"."VersionInfo" ("Version" bigint NOT NULL);
/* Committing Transaction */
/* VersionMigration migrated */
/* VersionUniqueMigration migrating ========================================== */

/* Beginning Transaction */
/* CreateIndex VersionInfo (Version) */
CREATE UNIQUE INDEX "UC_Version" ON "public"."VersionInfo" ("Version" ASC);
/* AlterTable VersionInfo */
/* No SQL statement executed. */
/* CreateColumn VersionInfo AppliedOn DateTime */
ALTER TABLE "public"."VersionInfo" ADD "AppliedOn" timestamp;
/* Committing Transaction */
/* VersionUniqueMigration migrated */
/* VersionDescriptionMigration migrating ===================================== */

/* Beginning Transaction */
/* AlterTable VersionInfo */
/* No SQL statement executed. */
/* CreateColumn VersionInfo Description String */
ALTER TABLE "public"."VersionInfo" ADD "Description" varchar(1024);
/* Committing Transaction */
/* VersionDescriptionMigration migrated */
/* 202003290925: CriacaoTabelaUsuario migrating ============================== */

/* Beginning Transaction */
/* CreateTable TB_Usuario */
CREATE TABLE "public"."TB_Usuario" ("IDUsuario" serial NOT NULL, "IDTicket" uuid NOT NULL, "NMUsuario" varchar(50) NOT NULL, "DSEmail" varchar(50) NOT NULL, "DTCriacao" timestamp NOT NULL, "DTAtualizacao" timestamp, CONSTRAINT "PK_Usuario" PRIMARY KEY ("IDUsuario"));COMMENT ON TABLE "public"."TB_Usuario" IS 'Tabela de cadastro de usuarios.';;COMMENT ON COLUMN "public"."TB_Usuario"."IDUsuario" IS 'Identificador usuario.';;COMMENT ON COLUMN "public"."TB_Usuario"."IDTicket" IS 'ID utilizado para identificar o usuário entre os microsserviços';;COMMENT ON COLUMN "public"."TB_Usuario"."NMUsuario" IS 'Nome do usuario';;COMMENT ON COLUMN "public"."TB_Usuario"."DSEmail" IS 'Email do usuario';;COMMENT ON COLUMN "public"."TB_Usuario"."DTCriacao" IS 'Data de criação do registo';;COMMENT ON COLUMN "public"."TB_Usuario"."DTAtualizacao" IS 'Data de atualização do registo';;
INSERT INTO "public"."VersionInfo" ("Version","AppliedOn","Description") VALUES (202003290925,'2021-03-29T13:43:08','CriacaoTabelaUsuario');
/* Committing Transaction */
/* 202003290925: CriacaoTabelaUsuario migrated */
/* Task completed. */
