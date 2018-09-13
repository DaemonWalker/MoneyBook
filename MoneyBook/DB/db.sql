/*
DATA_INFO
*/

PRAGMA foreign_keys = false;

-- ----------------------------
-- Table structure for DAY_INFO
-- ----------------------------
DROP TABLE IF EXISTS "DAY_INFO";
CREATE TABLE "DAY_INFO" (
  "DAY_ID" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  "DATE" text(10) NOT NULL DEFAULT (strftime('%Y%m%d', 'now')),
  UNIQUE ("DAY_ID" ASC)
);

-- ----------------------------
-- Table structure for TYPE_INFO
-- ----------------------------
DROP TABLE IF EXISTS "TYPE_INFO";
CREATE TABLE "TYPE_INFO" (
  "TYPE_ID" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  "TYPE_NAME" TEXT NOT NULL,
  "IO_FLAG" STRING(1),
  CONSTRAINT "PK_TYPE_INFO" UNIQUE ("TYPE_ID" ASC)
);

-- ----------------------------
-- Auto increment value for TYPE_INFO
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 5 WHERE name = 'TYPE_INFO';

-- ----------------------------
-- Indexes structure for table TYPE_INFO
-- ----------------------------
CREATE INDEX "IDX_TYPE_INFO"
ON "TYPE_INFO" (
  "TYPE_ID" ASC
);

-- ----------------------------
-- Auto increment value for DAY_INFO
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 9 WHERE name = 'DAY_INFO';

-- ----------------------------
-- Table structure for MONEY_INFO
-- ----------------------------
DROP TABLE IF EXISTS "MONEY_INFO";
CREATE TABLE "MONEY_INFO" (
  "MONEYINFO_ID" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  "USE_WAY" VARCHAR NOT NULL DEFAULT '',
  "USE_AMOUNT" DOUBLE (10,2) NOT NULL DEFAULT (0),
  "DAY_ID" INTEGER(11) NOT NULL,
  "TYPE_ID" INTEGER(11),
  CONSTRAINT "FK_MONEY_INFO_DAY" FOREIGN KEY ("DAY_ID") REFERENCES "DAY_INFO" ("DAY_ID") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "FK_MONEY_INFO_TYPE" FOREIGN KEY ("TYPE_ID") REFERENCES "TYPE_INFO" ("TYPE_ID") ON DELETE NO ACTION ON UPDATE NO ACTION,
  UNIQUE ("MONEYINFO_ID" ASC)
);

-- ----------------------------
-- Auto increment value for MONEY_INFO
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 9 WHERE name = 'MONEY_INFO';

PRAGMA foreign_keys = true;
