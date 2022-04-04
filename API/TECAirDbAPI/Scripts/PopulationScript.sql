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
('TIMJH', 'Boeing 737', 188, 250),
('ECATM', 'AirBus 320', 180, 240),
('N123A', 'Boeing 747', 500, 550),
('XACHU', 'AirBus 340', 370, 420),
('CVZYL', 'Boeing 777', 400, 450);

INSERT INTO flight
(customerid, namecustomer, lastnamecustomer, passcustomer, email, phone, studentid, university, miles)
VALUES
(117630483, 'Haziel', 'Gudiño', 'proba', 'mario.haziel@gmail.com', 84688275, 2017106391, 'ITCR', 1500),
(117790261, 'Fatima', 'Leiva', 'copey', 'leiva.fatima@gmail.com', 87419081, 2019153089, 'ITCR', 0),
(305270400, 'Valentina', 'Araya', 'recreo', 'carmen.araya@outlook.com', 72708906, 2018474940, 'ITCR', 500),
(117390704, 'Ruben', 'Salas', 'heredia', 'salas.rub@gmail.com', 86069199, 2017164846, 'ITCR', 1000),
(604540821, 'Mauricio', 'Valverde', 'oriental', 'morris@hotmail.com', 72052734, 'B158473847', 'UCR', 4500),
(305200614, 'Maria Jesus', 'Hernandez', 'tejar', 'maria.jesus@gmail.com', 86289831, 2017140368, 'ITCR', 500),
(117790840, 'Meybelline', 'Rodriguez', 'irene', 'meybe@gmail.com', 86733300, 'UCR', 'B165983784', 0),
(303850224, 'Vanessa', 'Pacheco', 'aguacaliente', 'pacheco.vanessa@yahoo.com', 60685479, DEFAULT, NULL, DEFAULT),
(115250307, 'Andres', 'Vargas', 'moravia', 'vargas.andres@outlook.com', 83171830, DEFAULT, NULL, DEFAULT),
(305080248, 'Valeria', 'Solano', 'ningning', 'valsolano@gmail.com', 60008745, DEFAULT, NULL, DEFAULT);

INSERT INTO flight
(flightid, bagquantity, userquantity, gate, departure, arrival, origin, destination, stops, status, price, discount, planeid, workerid)
VALUES
('IB7852', DEFAULT, DEFAULT, 7, '2022-08-22 16:40:00', '2022-08-24 13:15:00', 'SJO', 'ATH', 'IB7811,IB6342,IB3152', 'On Time', 935, DEFAULT, 'TIMJH', 118100573)
('IB7811', DEFAULT, DEFAULT, 7, '2022-08-22 16:40:00', '2022-08-22 17:55:00', 'SJO', 'SAL', '', 'On Time', 123, DEFAULT, 'TIMJH', 118100573)
('IB6342', DEFAULT, DEFAULT, 25, '2022-08-22 19:45:00', '2022-08-23 14:35:00', 'SAL', 'MAD', '', 'On Time', 598, DEFAULT, 'TIMJH', 118100573)
('IB3152', DEFAULT, DEFAULT, 19, '2022-08-24 08:35:00', '2022-08-24 13:15:00', 'MAD', 'ATH', '', 'On Time', 214, DEFAULT, 'TIMJH', 118100573)

('IB3217', DEFAULT, DEFAULT, 32, '2022-09-07 20:20:00', '2022-09-08 14:30:00', 'ATH', 'SJO', 'IB3281,IB6317', 'On Time', 935, DEFAULT, 'TIMJH', 118100573)
('IB3281', DEFAULT, DEFAULT, 32, '2022-09-07 20:20:00', '2022-09-07 23:10:00', 'ATH', 'MAD', '', 'On Time', 214, DEFAULT, 'TIMJH', 118100573)
('IB6317', DEFAULT, DEFAULT, 19, '2022-09-08 11:35:00', '2022-09-08 14:30:00', 'MAD', 'SJO', '', 'On Time', 721, DEFAULT, 'TIMJH', 118100573)