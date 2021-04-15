FROM mysql:5.6
COPY structure/*.sql /docker-entrypoint-initdb.d/
COPY conf/* /etc/mysql/conf.d/
RUN chmod uog-wx /etc/mysql/conf.d/*
#HACK to force --initialize using lowercase
RUN cat /etc/mysql/conf.d/lowercase.cnf >> /etc/mysql.my.cnf
# RUN cd /docker-entrypoint-initdb.d/ && tar -xvf *.gz && rm -f *.gz