create database canal;
go

drop table abonnement;
drop table bouquet_chaine;
drop table bouquet;
drop table chaine;
drop table client;
drop table region;
drop table reduction;

create table region (
    id int identity(1, 1) primary key,
    nom varchar(20) not null,
    signal double precision not null
);

create table client (
    id int identity(1, 1) primary key,
    nom varchar(20) not null,
    idregion int references region(id)
);

create table chaine (
    id int identity(1, 1) primary key,
    nom varchar(20) not null,
    prix double precision not null,
    signal double precision not null
);

create table bouquet (
    id int identity(1, 1) primary key,
    nom varchar(20) not null,
    reduction double precision,
    idclient int references client(id) -- Tompony raha personnalise
);

create table bouquet_chaine (
    idbouquet int references bouquet(id),
    idchaine int references chaine(id)
);

create table abonnement (
    id int identity(1, 1) primary key,
    idclient int references client(id),
    idbouquet int references bouquet(id),
    datedebut date not null,
    datefin date
);

create table reduction (
    nbrchaine int unique,
    valeur double precision
);

go

-- Lister tables
select TABLE_NAME
from INFORMATION_SCHEMA.TABLES
where TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'canal';
go