library("ggplot2")
# 2.1
(b <- ggplot(mpg, aes(cty, hwy, color = factor(cyl))) + geom_jitter() + geom_abline(colour = "grey20", size = 2))

labelled <- b + labs( x = "X", y = "Y", colour = "Cylinders", title = "Title")
(s <- labelled + theme_bw() + theme(plot.title = element_text(color= "blue", face = "bold", size = 6)))

# 2.2
s1 <- s + theme(legend.background = element_rect(fill = "red", size = 5, colour = "black"), legend.justification = c(0, 1), legend.position = c(0, 1),)
s1
# 2.3
s2 <- s1 + theme(axis.ticks = element_line(colour = "green", size = 4), panel.grid.major = element_line(colour = "lightblue", size = 0.8),)
s2
# 2.4
s3 <- s2+theme(axis.text = element_text(color = "green", size = 1), axis.title = element_text(color = "black", size = 2))
s3
# 2.5
s4 <- s3 + theme(plot.background = element_rect(fill = "red", colour = NA))
s4
# 2.6
s5 <- s4 + theme(panel.background = element_rect(fill = "grey", colour = "grey20"))
s5
s6 <- s5 + theme(panel.background = element_rect(colour = "gray", size = 3))
s6

# 2.7
df <- data.frame(x = 1:4, y = 1:4, z = c("a", "a", "b", "b"))
b <- ggplot(df, aes(x, y)) + geom_point() + facet_wrap(~z)
(b + theme(strip.background = element_rect(fill = "blue", color = "black", size = 4), strip.text = element_text(colour = "grey20", size = 20), panel.margin = unit(0.5, "in")))

# 4
mpg2 <- subset(mpg, cyl != 5 & drv %in% c("4", "f") & class != "compact")
(ggplot(mpg2, aes(displ, hwy)) + geom_blank() + xlab(NULL) + ylab(NULL) + facet_wrap(~class, ncol = 3, scales = "free"))

# 4.3
(ggplot(mpg2, aes(cty, hwy)) + geom_abline() + geom_jitter(width = 0.4, height = 0.4)+ facet_wrap(~cyl) + facet_wrap(~cyl, scales = "free"))
# 4.4
f <- data.frame(x = rnorm(120, c(0, 2, 4)), y = rnorm(120, c(1, 2, 1)), z = letters[1:3])
ggplot(f, aes(x, y)) + geom_point(aes(colour = z))
ggplot(f, aes(x, y)) + geom_point() + facet_wrap(~z)

library(dplyr)
ggplot(f, aes(x, y)) + geom_point() + geom_point(data = df %>% group_by(z) %>% summarise(x = mean(x), y = mean(y)) %>% rename(z2 = z), aes(colour = z2), size = 4) + facet_wrap(~z)

df2 <- dplyr::select(f, -z)
ggplot(f, aes(x, y)) + geom_point(data = df2, colour = "green") + geom_point(aes(colour = z)) + facet_wrap(~z)

# 5

pdf("../test.pdf", width = 5, height = 5)
ggplot(mpg, aes(displ, cty)) + geom_point()
dev.off()

ggplot(mpg, aes(displ, cty))+ geom_point()
ggsave("../test.pdf")
