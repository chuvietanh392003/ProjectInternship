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
