set.seed(100)
N<-10^6
coffee<-c(15,20,30,45,50)
p <- c(0.2,0.4,0.1,0.2,0.1)
X <- rbinom(n=N,size=260,prob=0.88)
Z <- rep(0,N)
for(i in 1:N){
Z[i] <- sum(sample(coffee,size=X[i],replace=TRUE,prob=p))
}
mean(Z)
sd(Z)
