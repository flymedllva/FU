# 1

data <- read.csv(file = 'evals.csv', encoding="UTF-8", stringsAsFactors=FALSE)
averare <- (bad <- 5/3) * 2

# 2
for (i in seq_len(nrow(data)))
  data[i,'estimation'] <- (function(score) if (score <= bad) "Низкая" else (if (score >= bad & score <= averare) "Средняя" else "Высокая"))(data[i,'score'])
head(data)


# 3
for (i in seq_len(nrow(data)))
  data[i,'estimation2'] <- ifelse(data[i,'score'] <= bad,"Низкая", ifelse((data[i,'score'] >= bad & data[i,'score'] <= averare),"Средняя","Высокая"))
head(data)

ifelse(TRUE, 'Да', 'Нет')

# 4
for (i in seq_len(nrow(data)))
  switch(data[i,'gender'],
         female={ data[i,'new_gender'] <- 'male'},
         male={data[i,'new_gender'] <- 'female'})
head(data)

# 5
(agg <- aggregate(data, by = list(data$gender), FUN = length))

# 6
(agg2 <- aggregate(data, by = list(data$gender, data$language), FUN = length))

# 7
data2 <- data
data2[,c("rank","ethnicity", "gender","language", "cls_level", "cls_profs", "cls_credits",
      "pic_outfit", "pic_color", "estimation", "estimation2", "new_gender")] <- list(NULL)

library(psych)
describe(data2)

# 8
data3 <- data
data3[,c("rank", "ethnicity", "language", "cls_level", "cls_profs", "cls_credits",
         "pic_outfit", "pic_color", "estimation", "estimation2", "new_gender")] <- list(NULL)

(dataframe <- describeBy(x = data2, group = data3$gender, mat=TRUE, fast=TRUE))

# 9
(dataframe <- describeBy(x = data2, group = list(data2$score, data3$gender), fast=TRUE))