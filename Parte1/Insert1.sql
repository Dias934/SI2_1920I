use TL51N_3
go
begin tran
	insert into MerFin values (1,'Mercado Monetário','MM')
	insert into MerFin values (2,'Mercado de capitais de renda variável','MCRV')
	insert into MerFin values (3,'Mercado de capitais de renda fixa','MCRF')

	insert into Instrumento (isin, descrição) values ('CA GEST','CA Monetário')
	insert into Instrumento (isin, descrição) values ('Caixagest','Caixagest Liquidez')
	insert into Instrumento (isin, descrição) values ('Montepio GA','Montepio Monetário de Curto Prazo')

	insert into Mer_A_Ins values(1,'CA GEST')
	insert into Mer_A_Ins values(1,'Caixagest')
	insert into Mer_A_Ins values(1,'Montepio GA')

	insert into Instrumento (isin, descrição) values ('Au','Ouro')
	insert into Instrumento (isin, descrição) values ('Ag','Prata')
	insert into Instrumento (isin, descrição) values ('Cu','Cobre')

	insert into Mer_A_Ins values(2,'Au')
	insert into Mer_A_Ins values(2,'Ag')
	insert into Mer_A_Ins values(2,'Cu')

	insert into Instrumento (isin, descrição) values ('US5949181045','Microsoft Corp.')
	insert into Instrumento (isin, descrição) values ('US38259P5089','Google Inc.')
	insert into Instrumento (isin, descrição) values ('US0378331005','Apple Inc.')

	insert into Mer_A_Ins values(3,'US5949181045')
	insert into Mer_A_Ins values(3,'US38259P5089')
	insert into Mer_A_Ins values(3,'US0378331005')

	insert into Triplos values ('CA GEST','2019-11-4 00:25:02',25.3)
	insert into Triplos values ('CA GEST','2019-11-4 23:55:59',25.2)
	insert into Triplos values ('CA GEST','2019-10-4 00:25:02',24.8)
	insert into Triplos values ('CA GEST','2019-10-4 23:55:59',25.0)
	insert into Triplos values ('CA GEST','2019-09-4 00:25:02',25.5)
	insert into Triplos values ('CA GEST','2019-09-4 23:55:59',25.6)

	insert into Triplos values ('Caixagest','2019-11-4 00:25:02',20.2)
	insert into Triplos values ('Caixagest','2019-11-4 23:55:59',20.3)
	insert into Triplos values ('Caixagest','2019-10-4 00:25:02',25.2)
	insert into Triplos values ('Caixagest','2019-10-4 23:55:59',25.3)
	insert into Triplos values ('Caixagest','2019-09-4 00:25:02',30.5)
	insert into Triplos values ('Caixagest','2019-09-4 23:55:59',31.6)

	insert into Triplos values ('Montepio GA','2019-11-4 00:25:02',17.2)
	insert into Triplos values ('Montepio GA','2019-11-4 23:55:59',17.1)
	insert into Triplos values ('Montepio GA','2019-10-4 00:25:02',16.8)
	insert into Triplos values ('Montepio GA','2019-10-4 23:55:59',16.9)
	insert into Triplos values ('Montepio GA','2019-09-4 00:25:02',16.5)
	insert into Triplos values ('Montepio GA','2019-09-4 23:55:59',16.5)

	insert into Triplos values ('Au','2019-11-4 00:25:02',6.65)
	insert into Triplos values ('Au','2019-11-4 23:55:59',6.64)
	insert into Triplos values ('Au','2019-10-4 00:25:02',6.63)
	insert into Triplos values ('Au','2019-10-4 23:55:59',6.64)
	insert into Triplos values ('Au','2019-09-4 00:25:02',6.65)
	insert into Triplos values ('Au','2019-09-4 23:55:59',6.66)

	insert into Triplos values ('Ag','2019-11-4 00:25:02',4.45)
	insert into Triplos values ('Ag','2019-11-4 23:55:59',4.44)
	insert into Triplos values ('Ag','2019-10-4 00:25:02',4.43)
	insert into Triplos values ('Ag','2019-10-4 23:55:59',4.44)
	insert into Triplos values ('Ag','2019-09-4 00:25:02',4.45)
	insert into Triplos values ('Ag','2019-09-4 23:55:59',4.46)

	insert into Triplos values ('Cu','2019-11-4 00:25:02',3.02)
	insert into Triplos values ('Cu','2019-11-4 23:55:59',3.02)
	insert into Triplos values ('Cu','2019-10-4 00:25:02',3.03)
	insert into Triplos values ('Cu','2019-10-4 23:55:59',3.03)
	insert into Triplos values ('Cu','2019-09-4 00:25:02',3.01)
	insert into Triplos values ('Cu','2019-09-4 23:55:59',3.00)

	insert into Triplos values ('US5949181045','2019-11-4 00:25:02',90.95)
	insert into Triplos values ('US5949181045','2019-11-4 23:55:59',90.96)
	insert into Triplos values ('US5949181045','2019-10-4 00:25:02',90.89)
	insert into Triplos values ('US5949181045','2019-10-4 23:55:59',90.90)
	insert into Triplos values ('US5949181045','2019-09-4 00:25:02',90.91)
	insert into Triplos values ('US5949181045','2019-09-4 23:55:59',90.89)

	insert into Triplos values ('US38259P5089','2019-11-4 00:25:02',160.34)
	insert into Triplos values ('US38259P5089','2019-11-4 23:55:59',160.33)
	insert into Triplos values ('US38259P5089','2019-10-4 00:25:02',160.20)
	insert into Triplos values ('US38259P5089','2019-10-4 23:55:59',160.19)
	insert into Triplos values ('US38259P5089','2019-09-4 00:25:02',160.10)
	insert into Triplos values ('US38259P5089','2019-09-4 23:55:59',160.10)

	insert into Triplos values ('US0378331005','2019-11-4 00:25:02',143.52)
	insert into Triplos values ('US0378331005','2019-11-4 23:55:59',143.51)
	insert into Triplos values ('US0378331005','2019-10-4 00:25:02',143.48)
	insert into Triplos values ('US0378331005','2019-10-4 23:55:59',143.55)
	insert into Triplos values ('US0378331005','2019-09-4 00:25:02',155.61)
	insert into Triplos values ('US0378331005','2019-09-4 23:55:59',155.20)

commit