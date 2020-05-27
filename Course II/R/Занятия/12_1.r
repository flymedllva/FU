library(magrittr)
library(psych)
library(dplyr)
library(ggplot2)

# 1
evals <- data.frame(read.csv("evals.csv", encoding = "UTF-8"))
evals %>% transform(score = score %>% { ifelse(. >= 4.5, "Высокая", ifelse(. >= 3, "Средняя", "Низкая")) })
evals %>% transform(gender_img = gender %>% { ifelse(. == "male", "♂︎", "♀︎") })
evals %>% aggregate(. ~ gender, data = ., FUN = length) %>% .[c("gender", "score")]
evals %>% aggregate(. ~ gender + language, data = ., FUN = length) %>% .[c("gender", "language", "score")]
(describe_by_gender <- describeBy(evals, group = evals$gender))
(describe_by_gender_and_language <- describeBy(evals, group = paste(evals$gender, evals$language)))

# 2
mtcars %>% .[c("cyl", "mpg", "disp")] %>% group_by(cyl) %>% summarise(mean_mpg = mean(mpg))
mtcars %>% .[c("cyl", "mpg", "disp")] %>% group_by(cyl) %>% summarise(mean_disp = mean(disp), min_mpg = min(mpg), max_mpg = max(mpg))
mtcars %>% .[c("cyl", "mpg", "disp")] %>% group_by(cyl) %>% summarise(mean_mpg = mean(mpg) * 1.6093)
mtcars %>% .[c("cyl", "mpg", "hp")] %>% mutate(mpg = mpg * 1.6093) %>% ggplot(., aes(mpg, hp)) + geom_point() + geom_smooth()
