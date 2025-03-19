-- This schema is generated based on the current DBContext. Please check the class Seeder to see.
CREATE TABLE "group" (
    id text NOT NULL,
    CONSTRAINT group_pkay PRIMARY KEY (id)
);


CREATE TABLE "user" (
    id text NOT NULL,
    email text NOT NULL,
    hash text NOT NULL,
    salt text NOT NULL,
    role text NOT NULL,
    CONSTRAINT user_pkey PRIMARY KEY (id)
);


CREATE TABLE groupmember (
    groupid text NOT NULL,
    userid text NOT NULL,
    CONSTRAINT groupmember_pk PRIMARY KEY (groupid, userid),
    CONSTRAINT groupmember_group_fk FOREIGN KEY (groupid) REFERENCES "group" (id),
    CONSTRAINT groupmember_user_fk FOREIGN KEY (userid) REFERENCES "user" (id)
);


CREATE TABLE message (
    messagetext text NOT NULL,
    id text,
    userid text NOT NULL,
    groupid text NOT NULL,
    timestamp timestamp with time zone NOT NULL,
    CONSTRAINT message_group_id_fk FOREIGN KEY (groupid) REFERENCES "group" (id),
    CONSTRAINT message_user_id_fk FOREIGN KEY (userid) REFERENCES "user" (id)
);


CREATE INDEX "IX_groupmember_userid" ON groupmember (userid);


CREATE INDEX "IX_message_groupid" ON message (groupid);


CREATE INDEX "IX_message_userid" ON message (userid);


