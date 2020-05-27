library(ggplot2)

# 2
g <- function(x) ggplot(mtcars, aes(hp, drat)) + geom_point() + scale_x_continuous(x)
g(quote(a ^ 2))
g(quote(b[2]))
g(quote(a != b))
g(quote(a %==% b))
g(quote(a <= b))
g(quote(a >= b))
g(quote(paste(a * degree, b)))
g(quote(paste(a,infinity, b)))

# 3
ggplot(mtcars, aes(hp, drat)) + geom_point() + labs(x=NULL, y=NULL)

# 4
ggplot(mtcars, aes(hp, drat)) + geom_point() + scale_x_log10(minor_breaks = 100)

# 5
ggplot(mtcars, aes(hp, drat)) + geom_point() + scale_x_continuous(breaks = 100,labels = "Test")

# 6
ggplot(mtcars, aes(hp, drat, fill=hp)) + geom_tile() + scale_fill_continuous(name="лошадей", labels=scales::unit_format(unit="лошадей"))

# 7
ggplot(mtcars, aes(hp, drat, fill=drat)) + geom_tile() + labs(x=NULL, y=NULL) + scale_fill_continuous(name="расход на 100км", labels=scales::unit_format(unit="потребляет"))

# 8
ggplot(mtcars, aes(hp, drat, fill=drat)) + geom_tile() + labs(x=NULL, y=NULL) + scale_fill_continuous(labels = NULL, name="Расход на 100км")

# 9
ggplot(mtcars, aes(hp, drat, fill=drat)) + geom_tile() + labs(x=NULL, y=NULL) + scale_fill_continuous(labels=scales::unit_format(unit="$"), name="Расход на 100км")

# 10
ggplot(mtcars, aes(hp, drat)) + geom_point() + scale_x_continuous(minor_breaks = mtcars$hp)

# 11
mtcars$gear <- as.factor(mtcars$gear)
ggplot(mtcars, aes(hp, drat, colour=qsec, shape=gear)) + geom_point() + geom_bar(stat="identity", width=.5)
ggplot(mtcars, aes(hp, drat, colour=qsec, shape=gear)) + geom_point() +
  geom_segment(aes(x=hp, xend=hp, y=0, yend=drat))
ggplot(mtcars, aes(hp, drat, colour=qsec, shape=gear)) + geom_count(col="tomato3", show.legend=F)

# 12
g <- ggplot(mtcars, aes(hp,drat)) + geom_point()
g + theme(axis.text = element_text(colour = "red"), panel.grid.major = element_line(colour = "black"))
g + theme_light()
g + theme_linedraw()

# 13
require(gridExtra)
g <- ggplot(mtcars, aes(hp,drat)) + geom_point()
grid.arrange(g + coord_flip(), g + coord_cartesian(), g + coord_fixed(1 * max(mtcars$hp) / max(mtcars$drat)), ncol=3)