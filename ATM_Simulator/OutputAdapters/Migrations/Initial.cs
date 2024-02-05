using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace OutputAdapters.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        return """
               create table bank_user
               (
                   "account_ID"    bigint not null
                       constraint bank_user_pk
                           primary key,
                   "Pin_Code"      bigint not null,
                   amount_of_money bigint default 0
               );


               create table admins
               (
                   id       integer not null
                       constraint admins_pk
                           primary key,
                   password varchar not null
               );

               """;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        return """
               drop table bank_user;
               drop table admins;
               """;
    }
}