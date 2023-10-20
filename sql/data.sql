insert into region values
    ('Analamanga', 70),
    ('Itasy', 80),
    ('Vakinankaratra', 83),
    ('Bongolava', 87)
;
go

insert into client values
    ('John Smith', 1),
    ('Alice Jones', 2),
    ('Bob Johnson', 3),
    ('Jane Davis', 4)
;
go

insert into chaine values
    ('Bein Sport', 3500, 85),
    ('M6', 2500, 80),
    ('Game one', 2800, 75),
    ('Syfy', 3000, 79),
    ('France24', 2100, 88),
    ('Nat Geo', 3100, 90),
    ('Cartoon network', 3600, 84),
    ('Nat Geo Wild', 3150, 91)
;
go

insert into bouquet values
    ('Tout canal', 0, null),
    ('Tongasoa', 0, null),
    ('Canal standart', 0, null),
    ('Family', 0, null)
;
go

insert into bouquet_chaine values
    (1, 1),
    (1, 2),
    (1, 3),
    (1, 4),
    (1, 5),
    (1, 6),
    (1, 8),

    (2, 2),
    (2, 4),
    (2, 6),

    (3, 1),
    (3, 2),
    (3, 4),
    (3, 6),
    (3, 8),

    (4, 3),
    (4, 4),
    (4, 5),
    (4, 6)
;
go

insert into abonnement values
    (1, 1, '2023-04-01', '2023-05-01'),
    (2, 2, '2023-05-11', '2023-06-11'),
    (2, 1, '2023-06-12', '2023-07-12'),
    (3, 3, '2023-04-20', '2023-05-20'),
    (4, 4, '2023-08-11', '2023-09-11'),
    (4, 2, '2023-03-12', '2023-04-12')
;
go

insert into reduction values
    (6, 2),
    (7, 4),
    (8, 6),
    (9, 8),
    (10, 10)
;
go