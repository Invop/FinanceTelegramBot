using Dapper;

namespace FinanceTelegramBot.Database
{
    public class DbInitializer
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public DbInitializer(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync("""
                                          create table if not exists bot_user (
                                            telegram_id bigint primary key,
                                            created_at timestamp default current_timestamp not null
                                          );
                                          """);

            await connection.ExecuteAsync("""
                                          create table if not exists payment_categories (
                                            id integer primary key,
                                            created_at timestamp default current_timestamp not null,
                                            name varchar(30) not null unique
                                          );
                                          """);
            await connection.ExecuteAsync("""
                                          create table if not exists transaction_types (
                                            id integer primary key,
                                            name varchar(10) not null unique
                                          );
                                          """ 
            );
            await connection.ExecuteAsync("""
                                          insert or ignore into transaction_types (id, name) values
                                          (1, 'income'),
                                          (2, 'expense');
                                          """);
            
            await connection.ExecuteAsync("""
                                          create table if not exists transactions (
                                              id integer primary key,
                                              description varchar(255) not null,
                                              amount decimal(18,2) not null,
                                              date timestamp not null default current_timestamp,
                                              payment_category_id integer not null,
                                              transaction_type_id integer not null,
                                              foreign key (payment_category_id) references payment_categories(id),
                                              foreign key (transaction_type_id) references transaction_types(id)
                                          );
                                          """);
            
            await connection.ExecuteAsync("""
                                          create table if not exists recurring_transactions (
                                              id integer primary key,
                                              amount decimal(18,2) not null,
                                              start_date timestamp not null default current_timestamp,
                                              end_date timestamp not null default (datetime('now', '+1 year')),
                                              frequency_in_days integer not null,
                                              transaction_type_id integer not null,
                                              foreign key (transaction_type_id) references transaction_types(id)
                                          );
                                          """);
            await connection.ExecuteAsync("""
                                          create table if not exists recurring_incomes (
                                              id integer primary key references recurring_transactions(id),
                                              source varchar(255) not null
                                          );
                                          
                                          """);
            await connection.ExecuteAsync("""
                                          create table if not exists recurring_payments (
                                              id integer primary key references recurring_transactions(id),
                                              description varchar(255) not null,
                                              payment_category_id integer not null,
                                              foreign key (payment_category_id) references payment_categories(id)
                                          );
                                          """);
            
            await connection.ExecuteAsync("""
                                          create table if not exists budgets (
                                              id integer primary key,
                                              name varchar(255) not null,
                                              amount decimal(18,2) not null,
                                              start_date timestamp not null default current_timestamp,
                                              end_date timestamp not null default (datetime('now', '+1 month')),
                                              payment_category_id integer not null,
                                              foreign key (payment_category_id) references payment_categories(id)
                                          );
                                          """);
            
            await connection.ExecuteAsync("""
                                          create table if not exists deposits (
                                              id integer primary key,
                                              amount decimal(18,2) not null,
                                              start_date timestamp not null default current_timestamp,
                                              end_date timestamp not null default (datetime('now', '+1 year')),
                                              bank_name varchar(255) not null
                                          );
                                          """);
        }
    }
}