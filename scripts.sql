create table member_tbl(
   id BIGINT(20) NOT NULL AUTO_INCREMENT,
   username VARCHAR(50) NOT NULL,
   senha VARCHAR(50) NOT NULL,
   idade INT NOT NULL,
   nome VARCHAR(50) NOT NULL,
   sobrenome VARCHAR(50) NOT NULL,
   PRIMARY KEY ( id )
);