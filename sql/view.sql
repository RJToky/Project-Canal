create or alter view v_detail_client as (
    select
        c.id idclient, c.nom nomclient, c.idregion,
        r.nom nomregion, r.signal
    from client c
    join region r on c.idregion = r.id
);
go

create or alter view v_detail_bouquet_chaine as (
    select
        b.id idbouquet, b.nom nombouquet, b.reduction, b.idclient,
        c.id idchaine, c.nom nomchaine, c.prix, c.signal
    from bouquet_chaine bc
    join bouquet b on bc.idbouquet = b.id
    join chaine c on bc.idchaine = c.id
);
go

create or alter view v_abonnement_client as (
    select
        c.id idclient, c.nom nomclient,
        b.id idbouquet, b.nom nombouquet, b.reduction,
        a.datedebut, a.datefin,
        (sum(vdbc.prix) - (sum(vdbc.prix) * b.reduction) / 100.0) montant
    from client c
    join abonnement a on a.idclient = c.id
    join bouquet b on b.id = a.idbouquet
    join v_detail_bouquet_chaine vdbc on b.id = vdbc.idbouquet
    group by c.id, c.nom, b.id, b.nom, b.reduction, a.datedebut, a.datefin
);
go

create or alter view v_detail_bouquet as (
    select
        b.*,
        sum(vdbc.prix) montantsansremise,
        (sum(vdbc.prix) - (sum(vdbc.prix) * b.reduction) / 100.0) montantavecremise
    from bouquet b
    join v_detail_bouquet_chaine vdbc on b.id = vdbc.idbouquet
    group by b.id, b.nom, b.reduction, b.idclient
);
go