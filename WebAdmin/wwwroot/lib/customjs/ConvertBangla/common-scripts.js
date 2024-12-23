function ag(g, text) {
	if (document.selection) {
		g.focus();
		aO = document.selection.createRange();
		aO.text = text;
		aO.collapse(true);
		aO.select();
	} else if (g.selectionStart || g.selectionStart == '0') {
		var B = g.selectionStart;
		var bM = g.selectionEnd;
		var scrollTop = g.scrollTop;
		B = (B == -1 ? g.value.length : B);
		g.value = g.value.substring(0, B) + text + g.value.substring(bM, g.value.length);
		g.focus();
		g.selectionStart = B + text.length;
		g.selectionEnd = B + text.length;
		g.scrollTop = scrollTop;
	} else {
		var scrollTop = g.scrollTop;
		g.value += value;
		g.focus();
		g.scrollTop = scrollTop;
	}
	ab = ab + text;
};


function act(g, text) {
	if (document.selection) {
		g.focus();
		aO = document.selection.createRange();
		aO.text = text;
		aO.collapse(true);
		aO.select();
	} else if (g.selectionStart || g.selectionStart == '0') {
		var B = g.selectionStart;
		var bM = g.selectionEnd;
		var scrollTop = g.scrollTop;
		B = (B == -1 ? g.value.length : B);
		g.value = g.value.substring(0, B) + text + g.value.substring(bM, g.value.length);
		g.focus();
		g.selectionStart = B + text.length;
		g.selectionEnd = B + text.length;
		g.scrollTop = scrollTop;
	} else {
		var scrollTop = g.scrollTop;
		g.value += value;
		g.focus();
		g.scrollTop = scrollTop;
	}
	ab = ab + text;
};

function H(g, value, bh) {
	if (document.selection) {
		g.focus();
		aO = document.selection.createRange();
		if (g.value.length >= bh) {
			aO.moveStart('character', -1 * (bh));
		}
		aO.text = value;
		aO.collapse(true);
		aO.select();
	} else if (g.selectionStart || g.selectionStart == 0) {
		g.focus();
		var B = g.selectionStart - bh;
		var bM = g.selectionEnd;
		var scrollTop = g.scrollTop;
		B = (B == -1 ? g.value.length : B);
		g.value = g.value.substring(0, B) + value + g.value.substring(bM, g.value.length);
		g.focus();
		g.selectionStart = B + value.length;
		g.selectionEnd = B + value.length;
		g.scrollTop = scrollTop;
	} else {
		var scrollTop = g.scrollTop;
		g.value += value;
		g.focus();
		g.scrollTop = scrollTop;
	}
	ab = ab.substring(0, ab.length - bh) + value;
};

function eM(e) {
	if (!e) e = window.event;
	if (!e) return false;
	var cT = e.which ? e.which : (e.keyCode ? e.keyCode : (e.charCode ? e.charCode : 0));
	var dA = e.shiftKey || (e.eh && (e.eh & 4));
	return ((cT > 64 && cT < 91 && !dA) || (cT > 96 && cT < 123 && dA));
};

function cw(id) {
	if (document.getElementById) {
		document.getElementById(id).style.display = 'none';
	} else {
		if (document.layers) {
			document.id.display = 'none';
		} else {
			document.all.id.style.display = 'none';
		}
	}
};

function cA(id) {
	if (document.getElementById) {
		document.getElementById(id).style.display = 'block';
	} else {
		if (document.layers) {
			document.id.display = 'block';
		} else {
			document.all.id.style.display = 'block';
		}
	}
};

function bA(f) {
	if (f == '০' || f == '১' || f == '২' || f == '৩' || f == '৪' || f == '৫' || f == '৬' || f == '৭' || f == '৮' || f == '৯') return true;
	return false;
};

function ao(f) {
	if (f == 'ি' || f == 'ৈ' || f == 'ে') return true;
	return false;
};

function aJ(f) {
	if (f == 'া' || f == 'ো' || f == 'ৌ' || f == 'ৗ' || f == 'ু' || f == 'ূ' || f == 'ী' || f == 'ৃ') return true;
	return false;
};

function ah(f) {
	if (ao(f) || aJ(f)) return true;
	return false;
};

function v(f) {
	if (f == 'ক' || f == 'খ' || f == 'গ' || f == 'ঘ' || f == 'ঙ' || f == 'চ' || f == 'ছ' || f == 'জ' || f == 'ঝ' || f == 'ঞ' || f == 'ট' || f == 'ঠ' || f == 'ড' || f == 'ঢ' || f == 'ণ' || f == 'ত' || f == 'থ' || f == 'দ' || f == 'ধ' || f == 'ন' || f == 'প' || f == 'ফ' || f == 'ব' || f == 'ভ' || f == 'ম' || f == 'শ' || f == 'ষ' || f == 'স' || f == 'হ' || f == 'য' || f == 'র' || f == 'ল' || f == 'য়' || f == 'ং' || f == 'ঃ' || f == 'ঁ' || f == 'ৎ') return true;
	return false;
};

function Q(f) {
	if (f == 'অ' || f == 'আ' || f == 'ই' || f == 'ঈ' || f == 'উ' || f == 'ঊ' || f == 'ঋ' || f == 'ঌ' || f == 'এ' || f == 'ঐ' || f == 'ও' || f == 'ঔ') return true;
	return false;
};

function aF(f) {
	if (f == 'ং' || f == 'ঃ' || f == 'ঁ') return true;
	return false;
};

function bS(f) {
	if (f == "্য" || f == "্র") return true;
	return false;
};

function D(f) {
	if (f == '্') return true;
	return false;
};

function eT(f) {
	if (bA(f) || ah(f) || v(f) || Q(f) || aF(f) || bS(f) || D(f)) return true;
	return false;
};

function eu(bJ) {
	if (bJ >= 0 && bJ < 128) return true;
	return false;
};

function cy(C) {
	if (C == ' ' || C == '\t' || C == '\n' || C == '\r') return true;
	return false;
};

function cJ(f) {
	var ac = '';
	if (f == 'া') ac = 'আ';
	else if (f == 'ি') ac = 'ই';
	else if (f == 'ী') ac = 'ঈ';
	else if (f == 'ু') ac = 'উ';
	else if (f == 'ূ') ac = 'ঊ';
	else if (f == 'ৃ') ac = 'ঋ';
	else if (f == 'ে') ac = 'এ';
	else if (f == 'ৈ') ac = 'ঐ';
	else if (f == 'ো') ac = 'ও';
	else if (f == "ো") ac = 'ও';
	else if (f == 'ৌ') ac = 'ঔ';
	else if (f == "ৌ") ac = 'ঔ';
	return ac;
};

function bc(f) {
	var bT = '';
	if (f == 'আ') bT = 'া';
	else if (f == 'ই') bT = 'ি';
	else if (f == 'ঈ') bT = 'ী';
	else if (f == 'উ') bT = 'ু';
	else if (f == 'ঊ') bT = 'ূ';
	else if (f == 'ঋ') bT = 'ৃ';
	else if (f == 'এ') bT = 'ে';
	else if (f == 'ঐ') bT = 'ৈ';
	else if (f == 'ও') bT = 'ো';
	else if (f == 'ঔ') bT = 'ৌ';
	return bT;
}