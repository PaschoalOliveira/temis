create table member_tbl(
   id BIGINT(20) NOT NULL AUTO_INCREMENT,
   username VARCHAR(50) NOT NULL,
   senha VARCHAR(50) NOT NULL,
   idade INT NOT NULL,
   nome VARCHAR(50) NOT NULL,
   sobrenome VARCHAR(50) NOT NULL,
   PRIMARY KEY ( id )
);

create table team(
   id BIGINT(20) NOT NULL AUTO_INCREMENT,
   "name" VARCHAR(50) NOT NULL,
   "description" VARCHAR(50) NOT NULL,
   PRIMARY KEY ( id )
);

create table team_member(
   member_id BIGINT(50) NOT NULL,
   team_id BIGINT(20) NOT NULL,
   foreign key (member_id) references memer (id),
   foreign key (team_id) references team (id),
);

create table judging_instance(
   id BIGINT(20) NOT NULL AUTO_INCREMENT,
   member_id BIGINT(50) NOT NULL,
   team_id BIGINT(20) NOT NULL,
   foreign key (member_id) references memer (id),
   foreign key (team_id) references team (id),
);

create table process(
   id BIGINT(20) NOT NULL AUTO_INCREMENT,
   member_id BIGINT(50) NOT NULL,
   "status" VARCHAR(50) NOT NULL,
   status_update DATE NOT NULL,
   create_date DATE NOT NULL,
   foreign key (member_id) references memer (id),
   foreign key (team_id) references team (id),
);

create table process(
   id BIGINT(20) NOT NULL AUTO_INCREMENT,
   member_id BIGINT(50) NOT NULL,
   "status" VARCHAR(50) NOT NULL,
   status_update DATE NOT NULL,
   create_date DATE NOT NULL,
   foreign key (member_id) references memer (id),
   foreign key (team_id) references team (id),
);

create table judgment(
   id BIGINT(20) NOT NULL AUTO_INCREMENT,
   "date" DATE NOT NULL,
   veredict VARCHAR(50),
   process_id  BIGINT(50) NOT NULL,
   foreign key (process_id) references process (id),
);