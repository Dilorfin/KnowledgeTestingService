import { NgbTimeStruct, NgbTimeAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Injectable } from '@angular/core';

@Injectable()
export class NgbTimeMillisecondsAdapter extends NgbTimeAdapter<number> {

	fromModel(value: number | null): NgbTimeStruct | null {
		if (!value) {
			return null;
		}
		let _time = new Date(value);
			return {
				hour: _time.getUTCHours(),
				minute: _time.getUTCMinutes(),
				second: _time.getUTCSeconds()
			};
	}

	toModel(time: NgbTimeStruct | null): number | null {
		if(!time){
			return null;
		}
		let _time = new Date(0);
		_time.setUTCHours(time.hour);
		_time.setUTCMinutes(time.minute);
		_time.setUTCSeconds(time.second);

		return _time.getTime();
	}
}