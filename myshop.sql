--
-- PostgreSQL database dump
--

-- Dumped from database version 15.1 (Debian 15.1-1.pgdg110+1)
-- Dumped by pg_dump version 15.1

-- Started on 2023-01-14 18:06:07

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE myshopdb;
--
-- TOC entry 3344 (class 1262 OID 16448)
-- Name: myshopdb; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE myshopdb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE myshopdb OWNER TO postgres;

\connect myshopdb

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 16529)
-- Name: price; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.price (
    productid integer NOT NULL,
    price numeric NOT NULL
);


ALTER TABLE public.price OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16483)
-- Name: product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product (
    productid integer NOT NULL,
    productname character varying(40) NOT NULL,
    productbrand character varying(40) NOT NULL,
    productsize character varying(10) NOT NULL
);


ALTER TABLE public.product OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16482)
-- Name: product_productid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_productid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.product_productid_seq OWNER TO postgres;

--
-- TOC entry 3345 (class 0 OID 0)
-- Dependencies: 214
-- Name: product_productid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_productid_seq OWNED BY public.product.productid;


--
-- TOC entry 216 (class 1259 OID 16519)
-- Name: stock; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.stock (
    productid integer NOT NULL,
    quantity integer NOT NULL
);


ALTER TABLE public.stock OWNER TO postgres;

--
-- TOC entry 3184 (class 2604 OID 16486)
-- Name: product productid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product ALTER COLUMN productid SET DEFAULT nextval('public.product_productid_seq'::regclass);


--
-- TOC entry 3338 (class 0 OID 16529)
-- Dependencies: 217
-- Data for Name: price; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.price (productid, price) FROM stdin;
4	42
5	4242
6	42
7	42
8	42
9	42
10	42
11	42
12	42
13	42
14	42
15	42
16	42
17	42
18	42
19	42
20	42
21	42
22	42
23	42
24	42
25	42
26	42
27	42
28	42
29	42
30	42
31	42
32	42
33	42
34	42
35	42
36	42
37	42
38	42
39	404
40	404
41	404
42	404
43	404
44	404
45	404
46	404
47	404
48	404
49	404
50	404
51	404
52	404
53	404
54	404
55	404
56	404
57	404
58	404
59	404
60	404
61	404
62	404
63	404
64	404
65	404
66	404
67	404
68	404
69	404
70	404
71	404
72	404
73	404
74	404
75	404
76	404
77	404
78	404
79	4242
80	4242
81	4242
82	4242
83	4242
84	4242
85	4242
86	4242
87	4242
88	4242
89	4242
90	4242
91	4242
92	4242
93	4242
94	4242
95	4242
96	4242
97	4242
98	4242
99	4242
100	4242
101	4242
102	4242
103	4242
104	4242
105	4242
106	4242
107	4242
108	4242
\.


--
-- TOC entry 3336 (class 0 OID 16483)
-- Dependencies: 215
-- Data for Name: product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product (productid, productname, productbrand, productsize) FROM stdin;
4	TestNameUpdateas	testbrandUpdateas	L
5	SwagSwag	SwagSwag	S
6	T-Shirt	Sarenza	L
7	T-Shirt	Sarenza	L
8	T-Shirt	Sarenza	L
9	T-Shirt	Sarenza	L
10	T-Shirt	Sarenza	L
11	T-Shirt	Sarenza	L
12	T-Shirt	Sarenza	L
13	T-Shirt	Sarenza	L
14	T-Shirt	Sarenza	L
15	T-Shirt	Sarenza	L
16	T-Shirt	Sarenza	L
17	T-Shirt	Sarenza	L
18	T-Shirt	Sarenza	L
19	T-Shirt	Sarenza	L
20	T-Shirt	Sarenza	L
21	T-Shirt	Sarenza	L
22	T-Shirt	Sarenza	L
23	T-Shirt	Sarenza	L
24	T-Shirt	Sarenza	L
25	T-Shirt	Sarenza	L
26	T-Shirt	Sarenza	L
27	T-Shirt	Sarenza	L
28	T-Shirt	Sarenza	L
29	T-Shirt	Sarenza	L
30	T-Shirt	Sarenza	L
31	T-Shirt	Sarenza	L
32	T-Shirt	Sarenza	L
33	T-Shirt	Sarenza	L
34	T-Shirt	Sarenza	L
35	T-Shirt	Sarenza	L
36	T-Shirt	Sarenza	L
37	T-Shirt	Sarenza	L
38	T-Shirt	Sarenza	L
39	Pantalon	Sarenza	M
40	Pantalon	Sarenza	M
41	Pantalon	Sarenza	M
42	Pantalon	Sarenza	M
43	Pantalon	Sarenza	M
44	Pantalon	Sarenza	M
45	Pantalon	Sarenza	M
46	Pantalon	Sarenza	M
47	Pantalon	Sarenza	M
48	Pantalon	Sarenza	M
49	Pantalon	Sarenza	M
50	Pantalon	Sarenza	M
51	Pantalon	Sarenza	M
52	Pantalon	Sarenza	M
53	Pantalon	Sarenza	M
54	Pantalon	Sarenza	M
55	Pantalon	Sarenza	M
56	Pantalon	Sarenza	M
57	Pantalon	Sarenza	M
58	Pantalon	Sarenza	M
59	Pantalon	Sarenza	M
60	Pantalon	Sarenza	M
61	Pantalon	Sarenza	M
62	Pantalon	Sarenza	M
63	Pantalon	Sarenza	M
64	Pantalon	Sarenza	M
65	Pantalon	Sarenza	M
66	Pantalon	Sarenza	M
67	Pantalon	Sarenza	M
68	Pantalon	Sarenza	M
69	Pantalon	Sarenza	M
70	Pantalon	Sarenza	M
71	Pantalon	Sarenza	M
72	Pantalon	Sarenza	M
73	Pantalon	Sarenza	M
74	Pantalon	Sarenza	M
75	Pantalon	Sarenza	M
76	Pantalon	Sarenza	M
77	Pantalon	Sarenza	M
78	Pantalon	Sarenza	M
79	Veste	Sarenza	S
80	Veste	Sarenza	S
81	Veste	Sarenza	S
82	Veste	Sarenza	S
83	Veste	Sarenza	S
84	Veste	Sarenza	S
85	Veste	Sarenza	S
86	Veste	Sarenza	S
87	Veste	Sarenza	S
88	Veste	Sarenza	S
89	Veste	Sarenza	S
90	Veste	Sarenza	S
91	Veste	Sarenza	S
92	Veste	Sarenza	S
93	Veste	Sarenza	S
94	Veste	Sarenza	S
95	Veste	Sarenza	S
96	Veste	Sarenza	S
97	Veste	Sarenza	S
98	Veste	Sarenza	S
99	Veste	Sarenza	S
100	Veste	Sarenza	S
101	Veste	Sarenza	S
102	Veste	Sarenza	S
103	Veste	Sarenza	S
104	Veste	Sarenza	S
105	Veste	Sarenza	S
106	Veste	Sarenza	S
107	Veste	Sarenza	S
108	Veste	Sarenza	S
\.


--
-- TOC entry 3337 (class 0 OID 16519)
-- Dependencies: 216
-- Data for Name: stock; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.stock (productid, quantity) FROM stdin;
4	4
5	42
6	5
7	5
8	5
9	5
10	5
11	5
12	5
13	5
14	5
15	5
16	5
17	5
18	5
19	5
20	5
21	5
22	5
23	5
24	5
25	5
26	5
27	5
28	5
29	5
30	5
31	5
32	5
33	5
34	5
35	5
36	5
37	5
38	5
39	7
40	7
41	7
42	7
43	7
44	7
45	7
46	7
47	7
48	7
49	7
50	7
51	7
52	7
53	7
54	7
55	7
56	7
57	7
58	7
59	7
60	7
61	7
62	7
63	7
64	7
65	7
66	7
67	7
68	7
69	7
70	7
71	7
72	7
73	7
74	7
75	7
76	7
77	7
78	7
79	42
80	42
81	42
82	42
83	42
84	42
85	42
86	42
87	42
88	42
89	42
90	42
91	42
92	42
93	42
94	42
95	42
96	42
97	42
98	42
99	42
100	42
101	42
102	42
103	42
104	42
105	42
106	42
107	42
108	42
\.


--
-- TOC entry 3346 (class 0 OID 0)
-- Dependencies: 214
-- Name: product_productid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_productid_seq', 108, true);


--
-- TOC entry 3190 (class 2606 OID 16535)
-- Name: price price_productid_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.price
    ADD CONSTRAINT price_productid_key UNIQUE (productid);


--
-- TOC entry 3186 (class 2606 OID 16488)
-- Name: product product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (productid);


--
-- TOC entry 3188 (class 2606 OID 16523)
-- Name: stock stock_productid_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stock
    ADD CONSTRAINT stock_productid_key UNIQUE (productid);


--
-- TOC entry 3192 (class 2606 OID 16536)
-- Name: price price_productid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.price
    ADD CONSTRAINT price_productid_fkey FOREIGN KEY (productid) REFERENCES public.product(productid);


--
-- TOC entry 3191 (class 2606 OID 16524)
-- Name: stock stock_productid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stock
    ADD CONSTRAINT stock_productid_fkey FOREIGN KEY (productid) REFERENCES public.product(productid);


-- Completed on 2023-01-14 18:06:07

--
-- PostgreSQL database dump complete
--

