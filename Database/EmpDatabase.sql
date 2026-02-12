use YOTEI

create table ES_YDENPYO (
DENPYONO  number primary key not null ,
KAIKEIND  number,							
UKETUKEDT varchar2(30),		
DENPYODT varchar2(30),										
BUMONCD_YKANR varchar2(30),
BIKO varchar2(30),
SUITOKB	varchar2(30),		
SHIHARAIDT varchar2(30),
KINGAKU	number,
INSERT_OPE_ID varchar2(30),
INSERT_PGM_ID varchar2(30) default 'AWCYO26001',
INSERT_PGM_PRM	varchar2(30) default '00000' ,
INSERT_DATE	varchar2(30),
UPDATE_OPE_ID varchar2(30),
UPDATE_PGM_ID varchar2(30) default 'AWCYO26001',
UPDATE_PGM_PRM varchar2(30) default '00000',
UPDATE_DATE	varchar2(30)
);

create sequence ES_ID
start with 1
increment by 1
nocache;

create or replace trigger UPDATE_ES_ID
before insert on ES_YDENPYO
for each row
begin
  if :new.DENPYONO is null then
    select ES_ID.nextval
    into :new.DENPYONO
    from DUAL;
  end if;
end;


create table ES_YDENPYOD(
GYONO  number ,
DENPYONO number,							
IDODT varchar2(30),		
SHUPPATSUPLC  varchar2(30),										
MOKUTEKIPLC  varchar2(30),
KEIRO  varchar2(30),
KINGAKU	number,		
INSERT_OPE_ID varchar2(30),
INSERT_PGM_ID varchar2(30) default 'AWCYO26001' ,
INSERT_PGM_PRM	varchar2(30) default '00000' ,
INSERT_DATE	varchar2(30),
UPDATE_OPE_ID varchar2(30),
UPDATE_PGM_ID varchar2(30) default 'AWCYO26001' ,
UPDATE_PGM_PRM varchar2(30)default '00000' ,
UPDATE_DATE	varchar2(30),
constraint DENPYONO foreign key(DENPYONO) REFERENCES  ES_YDENPYO(DENPYONO)
);

create table BUMOM (
BUMONCD	varchar2(30),									
BUMONNM	varchar2(30)
);		

INSERT INTO ES_YDENPYO VALUES (
    1002, 2024, '2024-04-03', '2024-04-03',
    'B002', '会議出席', '振込', '2024-04-15',
    80000,
    'user01', 'AWCYO26001', '00000', '2024-04-03 09:00:00',
    'user01', 'AWCYO26001', '00000', '2024-04-03 09:00:00'
);

INSERT INTO ES_YDENPYO VALUES (
    1003, 2024, '2024-04-05', '2024-04-05',
    'B003', '研修参加', '振込', '2024-04-20',
    120000,
    'user02', 'AWCYO26001', '00000', '2024-04-05 14:30:00',
    'user02', 'AWCYO26001', '00000', '2024-04-05 14:30:00'
);

select * from ES_YDENPYO
