'use strict';
describe('treasureCalculatorDataService', function () {
    var treasureCalculatorDataService, httpBackend;

    beforeEach(module('app'));

    beforeEach(inject(function (_treasureCalculatorDataService_, $httpBackend) {
        treasureCalculatorDataService = _treasureCalculatorDataService_;
        httpBackend = $httpBackend;
    }));

    it("should return 79 when provided a value of 3", function () {
        httpBackend.whenGET("/api/treasure/calculate/3").respond(79);
        treasureCalculatorDataService.calcTreasure(3).then(function (results) {
            expect(results.data).toEqual(79);
        });
        httpBackend.flush();
    });

    it("should return error when provided a value of -1", function () {
        httpBackend.whenGET("/api/treasure/calculate/-1").respond({
            "message": "Seriously?  -1 pirates?  What is this a ghost ship?"
        });
        treasureCalculatorDataService.calcTreasure(-1).then(function (results) {
            expect(results.data.message).toEqual("Seriously?  -1 pirates?  What is this a ghost ship?");
        });
        httpBackend.flush();
    });
});