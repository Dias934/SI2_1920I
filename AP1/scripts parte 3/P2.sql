SET TRANSACTION ISOLATION LEVEL Serializable
begin tran
Select *
From Critico
Where id=1
Update Critico Set nome='Nobody'
commit