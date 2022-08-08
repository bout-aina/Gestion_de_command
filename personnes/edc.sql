create table ARTICLE (
   IDCAT                int                  not null ,
  
   IDPROD               int                  not null ,
  
   IDA                  int                  not null IDENTITY(1,1) primary key,
   NOM                  char(30)             null,
   PRIXUNI              float         null,
    FOREIGN KEY (IDCAT) REFERENCES CATEGORIE(IDCAT) ,
	FOREIGN KEY (IDPROD) REFERENCES PRODUIT(IDPROD) on delete cascade,
  
)

create table CATEGORIE (
   IDCAT                int                  not null IDENTITY(1,1),
   NOM                  char(30)             null,
   DESCRIPTION          char(200)            null,
   constraint PK_CATEGORIE primary key (IDCAT)
)

create table PRODUIT (
   IDCAT                int                  not null ,
   FOREIGN KEY (IDCAT) REFERENCES CATEGORIE(IDCAT) on delete cascade,
   IDPROD               int                  not null IDENTITY(1,1) primary key ,
   NOM                  varchar(30)             null,
   DESCRIPTION          varchar(200)            null,
   
)

create table BONCOMMANDE (
   IDCO                  int                 not null IDENTITY(1,1),
   NUMBC                int                  not null,
   DATEBC               datetime             null,
   TYPECB               char(30)             null,
   DATEEXP              datetime             null,
   ADRLIV               char(100)            null,
   constraint PK_BONCOMMANDE primary key (IDCO, NUMBC)
)
create table client (
   ID                int                  not null IDENTITY(1,1) primary key,
   LOGIN                varchar(64)             null,
   MDP                  varchar(100)            null,
   NOM                  varchar(30)             null,
   PRENOM               varchar(30)             null,
   NUMTEL               varchar(20)             null,
   ADRMAIL              varchar(100)            null,
  
)