insert into region values
    ('Analamanga', 40),
    ('Boeny', 60),
    ('Betsiboka', 15),
    ('Alaotra-Mangoro', 90),
    ('Amoron''i Mania', 80),
    ('Atsimo-Atsinanana', 35),
    ('Atsinanana', 70),
    ('Analalava', 25),
    ('Androy', 50),
    ('Anosy', 20),
    ('Bongolava', 65),
    ('Diana', 30),
    ('Itasy', 45),
    ('Ihorombe', 85),
    ('Melaky', 55),
    ('Menabe', 75),
    ('Sava', 10),
    ('Sofia', 95),
    ('Vakinankaratra', 40),
    ('Vatovavy-Fitovinany', 55),
    ('Atsimo-Andrefana', 65),
    ('Haute Matsiatra', 70)
;

insert into client values
    ('Safidy', 1),
    ('Mendrika', 13),
    ('Razafy', 2),
    ('Malaza', 4)
;

insert into chaine values
    ('TF1', 5000, 60),
    ('TF2', 5000, 50),
    ('France 2', 4500, 70),
    ('France 4', 5000, 80),
    ('France 24', 5200, 85),
    ('TFI', 5500, 90),
    ('Disney', 6000, 95),
    ('Canal + ', 3000, 89),
    ('Being Sport ', 3500, 85),
    ('SPORT 3 ', 4000, 90),
    ('SPORT PRENIUM ', 6000, 99),
    ('SPORT LOCAL ', 2000, 99)
;

insert into bouquet values
    ('Bronze', 10, null),
    ('Silver', 5, null),
    ('Gold', 25, null),
    ('Prenium', 45, null),
    ('Sport', 50, null),
    ('Personnalise', 0, 1),
    ('TOUT CANAL', 10, null)
;

insert into bouquet_chaine values
    (1, 1),
    (1, 3),
    (1, 6),
    (1, 8),

    (2, 2),
    (2, 3),
    (2, 4),
    (2, 7),
    (2, 8),
    (2, 9),

    (3, 1),
    (3, 3),
    (3, 5),
    (3, 7),
    (3, 8),
    (3, 10),
    (3, 11),

    (4, 1),
    (4, 2),
    (4, 5),
    (4, 7),
    (4, 8),
    (4, 9),
    (4, 10),
    (4, 11),

    (5, 9),
    (5, 10),
    (5, 11),

    (6, 1),
    (6, 7),
    (6, 8),

    (7, 1),
    (7, 2),
    (7, 3),
    (7, 4),
    (7, 5),
    (7, 6),
    (7, 7),
    (7, 8),
    (7, 9),
    (7, 10),
    (7, 11),
    (7, 12)
;

go