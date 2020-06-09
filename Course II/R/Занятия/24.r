library(nycflights13)
library(dplyr)
library(ggplot2)

# 1
flights %>% arrange(year, month, day, sched_dep_time, carrier, flight) %>% mutate(flight_id = row_number()) %>% glimpse()

# 2
Lahman::Batting %>% count(playerID, yearID, stint) %>% filter(n > 1) %>% nrow()
babynames::babynames %>% count(year, sex, name) %>% filter(n > 1) %>% nrow()
nasaweather::atmos %>% count(lat, long, year, month) %>% filter(n > 1) %>% nrow()
fueleconomy::vehicles %>% count(id) %>% filter(n > 1) %>% nrow()
mutate(ggplot2::diamonds, id = row_number()) %>% distinct() %>% nrow()

# 3
n <- 100 # Полеты которые выполняются самолетами, совершившими не менее n полетов
flights %>%
  inner_join(select(airports, origin = faa, origin_lat = lat, origin_lon = lon), by = "origin") %>%
  inner_join(select(airports, dest = faa, dest_lat = lat, dest_lon = lon), by = "dest") %>%
  slice(1:n) %>% ggplot(aes(x = origin_lon, xend = dest_lon, y = origin_lat, yend = dest_lat)) +
  borders("state") + geom_segment(arrow = arrow(length = unit(.2, "cm"))) +
  coord_quickmap() + labs(y = "Latitude", x = "Longitude")

# 4
n <- 48 # Самые задерживаеме рейсов >= n часов
flights3 <- semi_join(weather,
                      flights %>% mutate(hour = sched_dep_time %/% 100) %>%
                                    group_by(origin, year, month, day, hour) %>%
                                    summarise(dep_delay = mean(dep_delay, na.rm = TRUE)) %>%
                                    ungroup() %>% arrange(desc(dep_delay)) %>% slice(1:n),
                      by = c("origin", "year", "month", "day", "hour")
)
select(flights3, temp, wind_speed, precip, time_hour) # Время задерживаемых рейсов
ggplot(flights3, aes(x = precip, y = wind_speed, color = temp)) + geom_point() +
    geom_text(aes(label=ifelse(temp, as.character(temp),'')), hjust = 0, vjust = 0)
# Больше всего задержек при высоком ветре, так же были задержки во время долгих осадков
