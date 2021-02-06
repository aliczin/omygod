call opm build
call opm test
call opm install ./omygod-1.0.0.ospx
call oscript examples/HelloSystem.os
call oscript examples/HttpHealthChecks.Arch.os
