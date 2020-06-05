library(nycflights13)
library(data.table)
library(dplyr)
df <- flights

# 1.1
filter(flights, arr_delay > 120)

# 1.2
filter(flights, dest %in% c("IAH","HOU"))

# 1.3
filter(flights, carrier %in% c("UA","AA","DL"))

# 1.4
filter(flights, month > 6 & month < 10)

# 1.5
filter(flights, arr_delay > 120, dep_delay < 2)

# 1.6
filter(flights, arr_delay <= 90, dep_delay > 120)

# 1.7
filter(flights, dep_time >= 000, dep_time <= 600)

# 2
filter(flights, between(dep_time, 000, 600))

# 3
filter(flights, is.na(dep_time))

# 4.1
arrange(filter(flights, is.na(dep_time)), desc(month))
# Или так :/
flights %>% filter(is.na(dep_time)) %>% arrange(desc(month))
# 4.2
flights %>% arrange(-dep_delay)
# 4.3
flights %>% arrange(air_time)
# 4.4
flights %>% arrange(-air_time)

# 5.1
select(flights, year, year, month, day) # Просто использует только 1
# 5.2
vars <- c("year", "month", "day", "dep_delay", "arr_delay")
select(flights, one_of(vars)) # Как перечисление полей таблицы
# 5.3
select(flights, contains("TIME")) # Выбирает все, что похоже на TIME

# 6.1
# Условие не понятное

# 6.2
(flights %>% arrange(-dep_delay) %>% .[1:10,])

# 7.1
df <- flights %>% filter(!is.na(dep_delay), !is.na(arr_delay))%>%
  group_by(year,month, day) %>% summarize(mean=mean(dep_delay))
ggplot(data=df, mapping=aes(x=month, y=mean)) + geom_point(alpha=1/5)
boxplot(mean ~ month, col = "coral", data = df)
# Ну в большенстве месяцев задержки примерно в 1 и тоже время.
# Наверно стоит глядеть на события рядом с днями выбросов

# 7.2
(flights %>% arrange(-dep_delay) %>% .[1,])$carrier

# 7.3
# Условие не понятное. Там данные даны по месяцам, вы предалгаете первую задержку посчитать. Что эти данные дадут?

