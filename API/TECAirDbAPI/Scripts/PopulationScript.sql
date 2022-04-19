INSERT INTO worker
(workerid, nameworker, lastnameworker, passworker)
VALUES
(118100573, 'Daniela', 'Brenes', 'dynamite'),
(117370005, 'Gabriel', 'Gonzalez', 'siuuu'),
(117730482, 'Oscar', 'Mendez', 'cot'),
(702790046, 'Aldo', 'Cambronero', 'guacimo'),
(702920019, 'Nayeli', 'Matarrita', 'hojancha');

INSERT INTO plane
(planeid, model, passengercap, bagcap)
VALUES
('TIMJH', 'Boeing 737', 210, 250),
('ECATM', 'AirBus 320', 180, 240),
('N123A', 'Boeing 747', 240, 550),
('XACHU', 'AirBus 340', 150, 420),
('CVZYL', 'Boeing 777', 120, 450);

INSERT INTO customer
(customerid, namecustomer, lastnamecustomer, passcustomer, email, phone, studentid, university, miles)
VALUES
(117630483, 'Haziel', 'Gudiño', 'proba', 'mario.haziel@gmail.com', 84688275, 2017106391, 'ITCR', 1500),
(117790261, 'Fatima', 'Leiva', 'copey', 'leiva.fatima@gmail.com', 87419081, 2019153089, 'ITCR', 0),
(305270400, 'Valentina', 'Araya', 'recreo', 'carmen.araya@outlook.com', 72708906, 2018474940, 'ITCR', 500),
(117390704, 'Ruben', 'Salas', 'heredia', 'salas.rub@gmail.com', 86069199, 2017164846, 'ITCR', 1000),
(604540821, 'Mauricio', 'Valverde', 'oriental', 'morris@hotmail.com', 72052734, 158473847, 'UCR', 4500),
(305200614, 'Maria Jesus', 'Hernandez', 'tejar', 'maria.jesus@gmail.com', 86289831, 2017140368, 'ITCR', 500),
(117790840, 'Meybelline', 'Rodriguez', 'irene', 'meybe@gmail.com', 86733300, 165983784, 'UCR', 0),
(303850224, 'Vanessa', 'Pacheco', 'aguacaliente', 'pacheco.vanessa@yahoo.com', 60685479, DEFAULT, NULL, DEFAULT),
(115250307, 'Andres', 'Vargas', 'moravia', 'vargas.andres@outlook.com', 83171830, DEFAULT, NULL, DEFAULT),
(305080248, 'Valeria', 'Solano', 'ningning', 'valsolano@gmail.com', 60008745, DEFAULT, NULL, DEFAULT);

INSERT INTO flight
(flightid, bagquantity, userquantity, gate, departure, arrival, origin, destination, stops, status, price, discount, planeid, workerid)
VALUES
('IB7852', DEFAULT, DEFAULT, 7, '2022-08-22 16:40:00', '2022-08-24 13:15:00', 'SJO/Costa Rica', 'ATH/Grecia', 'IB7811,IB6342,IB3152', 'Scheduled', 935, DEFAULT, 'TIMJH', 118100573),
('IB7811', DEFAULT, DEFAULT, 7, '2022-08-22 16:40:00', '2022-08-22 17:55:00', 'SJO/Costa Rica', 'SAL/El Salvador', '', 'Scheduled', 123, DEFAULT, 'TIMJH', 118100573),
('IB6342', DEFAULT, DEFAULT, 25, '2022-08-22 19:45:00', '2022-08-23 14:35:00', 'SAL/El Salvador', 'MAD/Madrid', '', 'Scheduled', 598, DEFAULT, 'TIMJH', 118100573),
('IB3152', DEFAULT, DEFAULT, 19, '2022-08-24 08:35:00', '2022-08-24 13:15:00', 'MAD/Madrid', 'ATH/Grecia', '', 'Scheduled', 214, DEFAULT, 'TIMJH', 118100573),
('IB3217', DEFAULT, DEFAULT, 32, '2022-09-07 20:20:00', '2022-09-08 14:30:00', 'ATH/Grecia', 'SJO/Costa Rica', 'IB3281,IB6317', 'Scheduled', 935, DEFAULT, 'TIMJH', 118100573),
('IB3281', DEFAULT, DEFAULT, 32, '2022-09-07 20:20:00', '2022-09-07 23:10:00', 'ATH/Grecia', 'MAD/Madrid', '', 'Scheduled', 214, DEFAULT, 'TIMJH', 118100573),
('IB6317', DEFAULT, DEFAULT, 19, '2022-09-08 11:35:00', '2022-09-08 14:30:00', 'MAD/Madrid', 'SJO/Costa Rica', '', 'Scheduled', 721, DEFAULT, 'TIMJH', 118100573),
('DL1721', DEFAULT, DEFAULT, 12, '2023-02-01 15:45:00', '2023-02-03 15:10:00', 'SJO/Costa Rica', 'HND/Japon/Japon', 'DL1756,DL466,DL121','Scheduled', 692, DEFAULT, 'CVZYL', 117370005),
('DL1756', DEFAULT, DEFAULT, 12, '2023-02-01 15:45:00', '2023-02-01 20:55:00', 'SJO/Costa Rica', 'ATL/Atlanta', '','Scheduled', 200, DEFAULT, 'CVZYL', 117370005),
('DL466', DEFAULT, DEFAULT, 9, '2023-02-02 08:55:00', '2023-02-01 10:30:00', 'ATL/Atlanta', 'MSP/Minessota', '','Scheduled', 50, DEFAULT, 'CVZYL', 117370005),
('DL121', DEFAULT, DEFAULT, 17, '2023-02-02 11:35:00', '2023-02-03 15:10:00', 'MSP/Minessota', 'HND/Japon', '','Scheduled', 442, DEFAULT, 'CVZYL', 117370005),
('DL6874', DEFAULT, DEFAULT, 25, '2023-02-08 19:20:00', '2023-02-09 07:35:00', 'HND/Japon', 'SJO/Costa Rica', 'DL68,DL2947,DL1974','Scheduled', 750, DEFAULT, 'CVZYL', 117370005),
('DL68', DEFAULT, DEFAULT, 25, '2023-02-08 19:20:00', '2023-02-08 11:30:00', 'HND/Japon', 'PDX/Portland/Portland', '','Scheduled', 520, DEFAULT, 'CVZYL', 117370005),
('DL2947', DEFAULT, DEFAULT, 1, '2023-02-08 17:00:00', '2023-02-08 19:20:00', 'PDX/Portland', 'LAX/Los Angeles', '','Scheduled', 95, DEFAULT, 'CVZYL', 117370005),
('DL1974', DEFAULT, DEFAULT, 3, '2023-02-08 22:50:00', '2023-02-09 07:35:00', 'PDX/Portland', 'SJO/Costa Rica', '','Scheduled', 135, DEFAULT, 'CVZYL', 117370005),
('LA2415', DEFAULT, DEFAULT, 6, '2022-09-25 17:03:00', '2022-09-26 07:50:00', 'SJO/Costa Rica', 'EZE/Argentina', 'LA2409,LA1321,LA6015','Scheduled', 457, DEFAULT, 'XACHU', 117370005),
('LA2409', DEFAULT, DEFAULT, 6, '2022-09-25 17:03:00', '2022-09-25 21:40:00', 'SJO/Costa Rica', 'LIM/Peru', '','Scheduled', 328, DEFAULT, 'XACHU', 117370005),
('LA1321', DEFAULT, DEFAULT, 15, '2022-09-25 23:00:00', '2022-09-26 03:33:00', 'LIM/Peru', 'ASU/Paraguay', '','Scheduled', 58, DEFAULT, 'XACHU', 117370005),
('LA6015', DEFAULT, DEFAULT, 20, '2022-09-26 05:00:00', '2022-09-26 07:50:00', 'ASU/Paraguay', 'EZE/Argentina', '','Scheduled', 71, DEFAULT, 'XACHU', 117370005),
('LA4608', DEFAULT, DEFAULT, 8, '2022-10-10 20:04:00', '2022-10-12 16:03:00', 'EZE/Argentina', 'SJO/Costa Rica', 'LA462,LA520,LA2408','Scheduled', 520, DEFAULT, 'XACHU', 117370005),
('LA462', DEFAULT, DEFAULT, 8, '2022-10-10 20:04:00', '2022-10-10 21:20:00', 'EZE/Argentina', 'SCH/Chile', '','Scheduled', 86, DEFAULT, 'XACHU', 117370005),
('LA520', DEFAULT, DEFAULT, 16, '2022-10-11 15:01:00', '2022-10-11 17:50:00', 'SCH/Chile', 'LIM/Peru', '','Scheduled', 59, DEFAULT, 'XACHU', 117370005),
('LA2408', DEFAULT, DEFAULT, 11, '2022-10-12 13:15:00', '2022-10-12 16:03:00', 'LIM/Peru', 'SJO/Costa Rica', '','Scheduled', 375, DEFAULT, 'XACHU', 117370005),
('AA1620', DEFAULT, DEFAULT, 22, '2022-11-20 13:56:00', '2022-11-21 20:30:00', 'SJO/Costa Rica', 'DOH/Catar', 'AA1600,AA1922,AA120','Scheduled', 1723, DEFAULT, 'N123A', 117370005),
('AA1600', DEFAULT, DEFAULT, 22, '2022-11-20 17:55:00', '2022-11-21 20:30:00', 'SJO/Costa Rica', 'MIA/Miami', '','Scheduled', 372, DEFAULT, 'N123A', 117370005),
('AA1922', DEFAULT, DEFAULT, 13, '2022-11-20 19:30:00', '2022-11-20 22:25:00', 'MIA/Miami', 'JFK/New York', '','Scheduled', 294, DEFAULT, 'N123A', 117370005),
('AA120', DEFAULT, DEFAULT, 28, '2022-11-21 00:20:00', '2022-11-21 20:30:00', 'MIA/Miami', 'DOH/Catar', '','Scheduled', 1057, DEFAULT, 'N123A', 117370005),
('AA1253', DEFAULT, DEFAULT, 14, '2022-11-30 01:35:00', '2022-11-30 21:32:00', 'DOH/Catar', 'SJO/Costa Rica', 'AA121,AA2148,AA1353','Scheduled', 1825, DEFAULT, 'N123A', 117370005),
('AA121', DEFAULT, DEFAULT, 14, '2022-11-30 01:35:00', '2022-11-30 08:15:00', 'DOH/Catar', 'JFK/New York', '','Scheduled', 1028, DEFAULT, 'N123A', 117370005),
('AA2148', DEFAULT, DEFAULT, 7, '2022-11-30 13:29:00', '2022-11-30 16:41:00', 'JFK/New York', 'MIA/Miami', '','Scheduled', 327, DEFAULT, 'N123A', 117370005),
('AA1353', DEFAULT, DEFAULT, 10, '2022-11-30 19:35:00', '2022-11-30 21:32:00', 'MIA/Miami', 'SJO/Costa Rica', '','Scheduled', 470, DEFAULT, 'N123A', 117370005),
('TK9690', DEFAULT, DEFAULT, 19, '2022-10-03 08:36:00', '2022-10-05 07:50:00', 'SJO/Costa Rica', 'CAI/Egipto', 'TK9603,TK801,TK690','Scheduled', 961, DEFAULT, 'TIMJH', 117370005),
('TK9603', DEFAULT, DEFAULT, 19, '2022-10-03 08:36:00', '2022-10-03 10:44:00', 'SJO/Costa Rica', 'PTY/Panama', '','Scheduled', 87, DEFAULT, 'TIMJH', 117370005),
('TK801', DEFAULT, DEFAULT, 25, '2022-10-03 19:55:00', '2022-10-04 16:45:00', 'PTY/Panama', 'IST/Turquia', '','Scheduled', 673, DEFAULT, 'TIMJH', 117370005),
('TK690', DEFAULT, DEFAULT, 7, '2022-10-05 06:35:00', '2022-11-30 21:32:00', 'IST/Turquia', 'CAI/Egipto', '','Scheduled', 201, DEFAULT, 'TIMJH', 117370005),
('AC2808', DEFAULT, DEFAULT, 12, '2022-10-19 16:35:00', '2022-10-20 21:15:00', 'CAI/Egipto', 'SJO/Costa Rica', 'AC2857,AC865,AC1808','Scheduled', 961, DEFAULT, 'TIMJH', 117370005),
('AC2857', DEFAULT, DEFAULT, 12, '2022-10-19 16:35:00', '2022-10-19 21:05:00', 'CAI/Egipto', 'LHR/Londres', '','Scheduled', 387, DEFAULT, 'TIMJH', 117370005),
('AC865', DEFAULT, DEFAULT, 9, '2022-10-20 14:05:00', '2022-10-20 16:15:00', 'LHR/Londres', 'YUL/Canada', '','Scheduled', 428, DEFAULT, 'TIMJH', 117370005),
('AC1808', DEFAULT, DEFAULT, 9, '2022-10-20 17:25:00', '2022-10-20 21:15:00', 'YUL/Canada', 'SJO/Costa Rica', '','Scheduled', 146, DEFAULT, 'TIMJH', 117370005);


INSERT INTO bag
(bagid, weight, color, price, customerid, flightid)
VALUES
('CO158', 35, "GREEN", 120,117630483,"IB6342"),
('AC402', 20, "BLUE", 80,117790261,"DL466"),
('GR631', 40, "RED", 140,117390704,"LA6015"),
('RQ471', 20, "BLACK", 80,604540821,"AA1253"),
('UA516', 60, "YELLOW", 200,115250307,"DL1974"),
('IV701', 15, "WHITE", 60,117630483,"IB6342"),
('GO891', 30, "GREY", 80,305270400,"DL121"),




/*CustomerIds

117630483
117790261
305270400
117790840
117390704
305200614
604540821
303850224
115250307
305080248


IB7852
IB7811
IB6342
IB3152
IB3217
IB3281
DL1721
DL1756
DL466
DL121
DL6874
DL68
DL2947
DL1974
LA2415
LA2409
LA1321
LA6015
LA4608
LA462
LA520
LA2408
AA1620
AA1600
AA1922
AA120
AA1253
AA121
AA2148
AA1353

*/