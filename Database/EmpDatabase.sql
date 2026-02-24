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


select * from KOTSUHI_MEISAI

CREATE TABLE KOTSUHI_MEISAI (
    
    GYONO              NUMBER(5)        NOT NULL,
    DENPYONO           NUMBER(10)       NOT NULL,
    
    IDODT              VARCHAR2(8),     -- YYYYMMDD
    SHUPPATSUPLC       VARCHAR2(100),
    MOKUTEKIPLC        VARCHAR2(100),
    KEIRO              VARCHAR2(200),
    KINGAKU            NUMBER(12,2),
    
    INSERT_OPE_ID      VARCHAR2(30),
    INSERT_PGM_ID      VARCHAR2(20),
    INSERT_PGM_PRM     VARCHAR2(20),
    INSERT_DATE        DATE,
    
    UPDATE_OPE_ID      VARCHAR2(30),
    UPDATE_PGM_ID      VARCHAR2(20),
    UPDATE_PGM_PRM     VARCHAR2(20),
    UPDATE_DATE        DATE,

    CONSTRAINT PK_KOTSUHI_MEISAI
        PRIMARY KEY (DENPYONO, GYONO),

    CONSTRAINT FK_KOTSUHI_DENPYO
        FOREIGN KEY (DENPYONO)
        REFERENCES ES_YDENPYO (DENPYONO)
);

INSERT INTO KOTSUHI_MEISAI 
(GYONO, DENPYONO, IDODT, SHUPPATSUPLC, MOKUTEKIPLC, KEIRO, KINGAKU,
 INSERT_OPE_ID, INSERT_PGM_ID, INSERT_PGM_PRM, INSERT_DATE,
 UPDATE_OPE_ID, UPDATE_PGM_ID, UPDATE_PGM_PRM, UPDATE_DATE)
VALUES
-- ===== 伝票番号 1000 (150000.5) =====
(1, 1000, '20240101', '東京', '横浜', 'JR東海道線', 50000,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

INSERT INTO KOTSUHI_MEISAI VALUES
(2, 1000, '20240101', '横浜', '東京', 'JR東海道線', 100000.5,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

--------------------------------------------------------

-- ===== 伝票番号 1001 (50000) =====
INSERT INTO KOTSUHI_MEISAI VALUES
(1, 1001, '20240203', '大阪', '京都', '新幹線', 30000,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

INSERT INTO KOTSUHI_MEISAI VALUES
(2, 1001, '20240203', '京都', '大阪', '新幹線', 20000,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

--------------------------------------------------------

-- ===== 伝票番号 1002 (300000) =====
INSERT INTO KOTSUHI_MEISAI VALUES
(1, 1002, '20240228', '名古屋', '東京', '新幹線', 150000,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

INSERT INTO KOTSUHI_MEISAI VALUES
(2, 1002, '20240301', '東京', '名古屋', '新幹線', 150000,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

--------------------------------------------------------

-- ===== 伝票番号 1004 (420000) =====
INSERT INTO KOTSUHI_MEISAI VALUES
(1, 1004, '20250130', '福岡', '東京', '飛行機', 250000,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

INSERT INTO KOTSUHI_MEISAI VALUES
(2, 1004, '20250201', '東京', '福岡', '飛行機', 170000,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

--------------------------------------------------------

-- ===== 伝票番号 1005 (Test - chưa có 金額 rõ) =====
INSERT INTO KOTSUHI_MEISAI VALUES
(1, 1005, '20260224', '札幌', '東京', '飛行機', 80000,
 'admin', 'AWCYO26001', '00000', SYSDATE,
 'admin', 'AWCYO26001', '00000', SYSDATE);

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
