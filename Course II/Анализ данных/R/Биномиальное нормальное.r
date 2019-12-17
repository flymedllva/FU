set.seed(100)
N<-10^6
X <- rbinom(n=N,size=700,prob=0.74)
Z <- rep(0,N)
for(i in 1:N){
Z[i] <- sum(rnorm(X[i],mean=3500,sd=50))
}
mean(Z)
sd(Z)
var(Z)
