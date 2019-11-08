use TL51N_3
go
begin tran
	insert into MerFin values (1,'Mercado Monetário','MM')
	insert into MerFin values (2,'Mercado de capitais de renda variável','MCRV')
	insert into MerFin values (3,'Mercado de capitais de renda fixa','MCRF')

	insert into Instrumento (isin, descrição,val_at) values ('CA GEST','CA Monetário',20)
	insert into Instrumento (isin, descrição,val_at) values ('Caixagest','Caixagest Liquidez',20)
	insert into Instrumento (isin, descrição,val_at) values ('Montepio GA','Montepio Monetário de Curto Prazo',20)

	insert into Mer_A_Ins values(1,'CA GEST')
	insert into Mer_A_Ins values(1,'Caixagest')
	insert into Mer_A_Ins values(1,'Montepio GA')

	insert into Instrumento (isin, descrição,val_at) values ('Au','Ouro',1)
	insert into Instrumento (isin, descrição,val_at) values ('Ag','Prata',1)
	insert into Instrumento (isin, descrição,val_at) values ('Cu','Cobre',1)

	insert into Mer_A_Ins values(2,'Au')
	insert into Mer_A_Ins values(2,'Ag')
	insert into Mer_A_Ins values(2,'Cu')

	insert into Instrumento (isin, descrição,val_at) values ('US5949181045','Microsoft Corp.',50)
	insert into Instrumento (isin, descrição,val_at) values ('US38259P5089','Google Inc.',50)
	insert into Instrumento (isin, descrição,val_at) values ('US0378331005','Apple Inc.',50)

	insert into Mer_A_Ins values(3,'US5949181045')
	insert into Mer_A_Ins values(3,'US38259P5089')
	insert into Mer_A_Ins values(3,'US0378331005')

	insert into Triplos values ('CA GEST',getdate(),25.3)
	insert into Triplos values ('CA GEST',getdate(),25.2)
	insert into Triplos values ('CA GEST',getdate(),24.8)
	insert into Triplos values ('CA GEST',getdate(),25.0)
	insert into Triplos values ('CA GEST',getdate(),25.5)
	insert into Triplos values ('CA GEST',getdate(),25.6)

	insert into Triplos values ('Caixagest',getdate(),20.2)
	insert into Triplos values ('Caixagest',getdate(),20.3)
	insert into Triplos values ('Caixagest',getdate(),25.2)
	insert into Triplos values ('Caixagest',getdate(),25.3)
	insert into Triplos values ('Caixagest',getdate(),30.5)
	insert into Triplos values ('Caixagest',getdate(),31.6)

	insert into Triplos values ('Montepio GA',getdate(),17.2)
	insert into Triplos values ('Montepio GA',getdate(),17.1)
	insert into Triplos values ('Montepio GA',getdate(),16.8)
	insert into Triplos values ('Montepio GA',getdate(),16.9)
	insert into Triplos values ('Montepio GA',getdate(),16.5)
	insert into Triplos values ('Montepio GA',getdate(),16.5)

	insert into Triplos values ('Au',getdate(),6.65)
	insert into Triplos values ('Au',getdate(),6.64)
	insert into Triplos values ('Au',getdate(),6.63)
	insert into Triplos values ('Au',getdate(),6.64)
	insert into Triplos values ('Au',getdate(),6.65)
	insert into Triplos values ('Au',getdate(),6.66)

	insert into Triplos values ('Ag',getdate(),4.45)
	insert into Triplos values ('Ag',getdate(),4.44)
	insert into Triplos values ('Ag',getdate(),4.43)
	insert into Triplos values ('Ag',getdate(),4.44)
	insert into Triplos values ('Ag',getdate(),4.45)
	insert into Triplos values ('Ag',getdate(),4.46)

	insert into Triplos values ('Cu',getdate(),3.52)
	insert into Triplos values ('Cu',getdate(),3.02)
	insert into Triplos values ('Cu',getdate(),3.03)
	insert into Triplos values ('Cu',getdate(),3.03)
	insert into Triplos values ('Cu',getdate(),3.01)
	insert into Triplos values ('Cu',getdate(),3.00)

	insert into Triplos values ('US5949181045',getdate(),90.95)
	insert into Triplos values ('US5949181045',getdate(),90.96)
	insert into Triplos values ('US5949181045',getdate(),90.89)
	insert into Triplos values ('US5949181045',getdate(),90.90)
	insert into Triplos values ('US5949181045',getdate(),90.91)
	insert into Triplos values ('US5949181045',getdate(),90.89)

	insert into Triplos values ('US38259P5089',getdate(),160.34)
	insert into Triplos values ('US38259P5089',getdate(),160.33)
	insert into Triplos values ('US38259P5089',getdate(),160.20)
	insert into Triplos values ('US38259P5089',getdate(),160.19)
	insert into Triplos values ('US38259P5089',getdate(),160.10)
	insert into Triplos values ('US38259P5089',getdate(),160.10)

	insert into Triplos values ('US0378331005',getdate(),143.52)
	insert into Triplos values ('US0378331005',getdate(),143.51)
	insert into Triplos values ('US0378331005',getdate(),143.48)
	insert into Triplos values ('US0378331005',getdate(),143.55)
	insert into Triplos values ('US0378331005',getdate(),155.61)
	insert into Triplos values ('US0378331005',getdate(),155.20)

	insert into Cliente values (111,111,'DiogoM')
	insert into Cliente values (222,222,'DiogoB')
	insert into Cliente values (333,333,'Manuel')

	insert into Contacto values (111,1,'Contacto DiogoM')
	insert into Contacto values (222,2,'Contacto DiogoB')
	insert into Contacto values (333,3,'Contacto Manuel')

	insert into Telefone values (111,1,351,9661444)
	insert into Email values (111,1,'diogoM@isel.pt')

	insert into Telefone values (222,2,351,96615555)
	insert into Email values (222,2,'diogoB@isel.pt')

	insert into Telefone values (333,3,351,9397)
	insert into Email values (333,3,'manuel@isel.pt')

	insert into Portfolio (cc,nome) values (111,'Portofolio DiogoM')
	insert into Portfolio (cc,nome) values (222,'Portofolio DiogoB')
	insert into Portfolio (cc,nome) values (333,'Portofolio Manuel')

	insert into Posições values (111,'Portofolio DiogoM','US0378331005',30)
	insert into Posições values (111,'Portofolio DiogoM','US38259P5089',80)
	insert into Posições values (111,'Portofolio DiogoM','US5949181045',50)
	insert into Posições values (111,'Portofolio DiogoM','Cu',400)
	insert into Posições values (111,'Portofolio DiogoM','Ag',200)
	insert into Posições values (111,'Portofolio DiogoM','Au',20)
	insert into Posições values (111,'Portofolio DiogoM','Caixagest',60)

	insert into Posições values (333,'Portofolio Manuel','US0378331005',45)
	insert into Posições values (333,'Portofolio Manuel','US38259P5089',75)
	insert into Posições values (333,'Portofolio Manuel','US5949181045',45)
	insert into Posições values (333,'Portofolio Manuel','Cu',200)
	insert into Posições values (333,'Portofolio Manuel','Ag',150)
	insert into Posições values (333,'Portofolio Manuel','Au',100)
	insert into Posições values (333,'Portofolio Manuel','Caixagest',80)

	insert into Posições values (222,'Portofolio DiogoB','US0378331005',10)
	insert into Posições values (222,'Portofolio DiogoB','US38259P5089',20)
	insert into Posições values (222,'Portofolio DiogoB','US5949181045',30)
	insert into Posições values (222,'Portofolio DiogoB','Cu',40)
	insert into Posições values (222,'Portofolio DiogoB','Ag',50)
	insert into Posições values (222,'Portofolio DiogoB','Au',60)
	insert into Posições values (222,'Portofolio DiogoB','Caixagest',70)
commit