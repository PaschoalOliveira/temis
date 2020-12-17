create table member(
   id BIGINT NOT NULL AUTO_INCREMENT,
   cpf VARCHAR(11) NOT NULL,
   name VARCHAR(20) NOT NULL,
   last_name VARCHAR(20) NOT NULL,
   age INT NOT NULL,
   role VARCHAR(10) NOT NULL,
   PRIMARY KEY ( id )
);

create table team(
   id BIGINT NOT NULL AUTO_INCREMENT,
   name VARCHAR(20) NOT NULL,
   description VARCHAR(50) NOT NULL,
   PRIMARY KEY ( id )
);

create table team_member(
   member_id BIGINT NOT NULL,
   team_id BIGINT NOT NULL,
   foreign key (member_id) references member (id),
   foreign key (team_id) references team (id)
);

create table judging_instance(
   id BIGINT NOT NULL AUTO_INCREMENT,
   member_id BIGINT,
   team_id BIGINT,
   foreign key (member_id) references member (id),
   foreign key (team_id) references team (id),
   ck_member_team CHECK (
      CASE WHEN member_id IS NULL THEN 0 ELSE 1 END +
      CASE WHEN team_id  IS NULL THEN 1 ELSE 1 END = 1
   )
   PRIMARY KEY ( id )
   
);

create table process(
   id BIGINT NOT NULL AUTO_INCREMENT,
   judging_instance_id BIGINT NOT NULL,
   status VARCHAR(50) NOT NULL,
   status_update DATE NOT NULL,
   create_date DATE NOT NULL,
   foreign key (judging_instance_id) references judging_instance (id),
   PRIMARY KEY ( id )
);

create table judgment(
   id BIGINT NOT NULL AUTO_INCREMENT,
   date DATE NOT NULL,
   veredict VARCHAR(50),
   process_id  BIGINT(50) NOT NULL,
   foreign key (process_id) references process (id),
   PRIMARY KEY ( id )
);