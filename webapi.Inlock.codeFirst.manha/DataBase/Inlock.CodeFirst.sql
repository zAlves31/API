INSERT INTO Estudio
VALUES (NEWID(),'Santa Monica'),(NEWID(),'Ubisof'),(NEWID(),'Bandai')



INSERT INTO Jogo
VALUES (NEWID(),'God of War','JOGO MANEIRO!','2018-10-09',10.99,'8E47C2C9-85EF-4F35-9D60-79FF79132B91'),
       (NEWID(),'Elden Ring','JOGO MANEIRO!','2022-08-29',30.99,'0A675EF6-9CB1-40FB-A78F-81FA3E64773D'),
	   (NEWID(),'Watch Dogs','JOGO MANEIRO!','2020-07-31',25.99,'BB7FEBC7-69AA-4C2C-9D90-225731F30F35')



INSERT INTO TiposUsuario
VALUES (NEWID(),'Administrador'),(NEWID(),'Comum')



INSERT INTO Usuario
VALUES (NEWID(),'adm@adm.com','admin','D8AE9810-8011-4859-B5A4-FCCF16F9D374'),
       (NEWID(),'comum@comum.com','comum','59C754A8-C673-4802-95DC-F6D8C3C8D34A')


SELECT * FROM Usuario
SELECT * FROM TiposUsuario
SELECT * FROM Jogo
SELECT * FROM Estudio

DELETE FROM Usuario WHERE IdUsuario = '0D78B993-C9F0-4D2B-AD57-1E87F033C592'