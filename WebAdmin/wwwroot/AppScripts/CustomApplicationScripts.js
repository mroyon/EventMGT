"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ExampleLogic = exports.customapplicationLogic = void 0;
class Player {
}
class customapplicationLogic {
    Task1() {
        console.log("Execute Task1");
        return new Promise((resolvefunc, rejectfunc) => {
            let x = 0;
            // DO Some Work
            ///
            //
            if (x == 0) {
                let player = new Player();
                player.id = 1;
                resolvefunc(player);
            }
            else {
                rejectfunc("Error:Task1");
            }
        });
    }
    ;
    Task2() {
        console.log("Execute Task2");
        return new Promise((resolvefunc, rejectfunc) => {
            let x = 0;
            // DO Some Work
            if (x == 0) {
                let player = new Player();
                player.id = 1;
                resolvefunc(player);
            }
            else {
                rejectfunc("Error: Task2");
            }
        });
    }
    ;
}
exports.customapplicationLogic = customapplicationLogic;
class ExampleLogic {
    ConsumeFunc() {
        let Task = new customapplicationLogic();
        Task.Task1()
            .then((value) => {
            console.log("Success Task1");
            Task.Task2()
                .then((value) => {
                console.log("Success Task2");
            })
                .catch((error) => {
                console.log(error);
            });
        })
            .catch((error) => {
            console.log(error);
        });
    }
}
exports.ExampleLogic = ExampleLogic;
//# sourceMappingURL=CustomApplicationScripts.js.map