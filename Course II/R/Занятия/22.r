library(readxl)
library(tidyverse)
library(dplyr)

# 1
df <- read_excel("Численность населения 2018 2.xlsx")

df1 <- df %>% fill(`Страна`, `Округ`, .direction = "down")
df1 <- df %>% fill(`Страна`, `Округ`, .direction = "up")
df1 <- df %>% fill(`Страна`, `Округ`, .direction = "downup")
df1 <- df %>% fill(`Страна`, `Округ`, .direction = "updown")

df11 <- df %>% pivot_longer(cols=starts_with("2"), names_to = "Year", values_to = "Population") %>%
  fill(`Страна`, `Округ`, .direction = "down")
df11
# 2

df2 <- who %>% pivot_longer(cols = new_sp_m014:newrel_f65, names_to = c("diagnosis", "gender", "age"),
                      names_pattern = "new_?(.*)_(.)(.*)", values_to = "count")
df2

# 3
df3 <- (world_bank_pop %>%
  pivot_longer(cols = starts_with("2"), names_to = "year", values_to = "population") %>%
  separate(col = "indicator", into = c("rubbish", "area", "variable")))[, -2] %>%
  pivot_wider(names_from = variable, values_from = population)
df3




  